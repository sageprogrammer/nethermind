//  Copyright (c) 2021 Demerzel Solutions Limited
//  This file is part of the Nethermind library.
// 
//  The Nethermind library is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  The Nethermind library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
// 

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nethermind.Blockchain;
using Nethermind.Blockchain.Find;
using Nethermind.Core;
using Nethermind.Core.Collections;
using Nethermind.Core.Crypto;
using Nethermind.Core.Extensions;
using Nethermind.Int256;
using Nethermind.JsonRpc;
using Nethermind.Logging;
using Nethermind.Mev.Data;
using Nethermind.Mev.Execution;
using Nethermind.TxPool.Collections;
using Org.BouncyCastle.Security;
using ILogger = Nethermind.Logging.ILogger;

namespace Nethermind.Mev.Source
{

    public class BundlePool : IBundlePool, ISimulatedBundleSource, IDisposable
    {
        private readonly IBlockFinalizationManager? _finalizationManager;
        private readonly ITimestamper _timestamper;
        private readonly IMevConfig _mevConfig;
        private readonly IBlockTree _blockTree;
        private readonly IBundleSimulator _simulator;
        private readonly BundleSortedPool _bundles;
        private readonly ConcurrentDictionary<Keccak, ConcurrentDictionary<MevBundle, SimulatedMevBundleContext>> _simulatedBundles = new();
        private readonly ILogger _logger;
        private readonly CompareMevBundleByBlock? _compareMevBundleByBlock;
        public BundlePool(
            IBlockTree blockTree, 
            IBundleSimulator simulator,
            IBlockFinalizationManager? finalizationManager,
            ITimestamper timestamper,
            IMevConfig mevConfig,
            ILogManager logManager)
        {
            _finalizationManager = finalizationManager;
            _timestamper = timestamper;
            _mevConfig = mevConfig;
            _blockTree = blockTree;
            _simulator = simulator;
            RegisterNewBlockTracking();
           
            _logger = logManager.GetClassLogger();

            _compareMevBundleByBlock = new CompareMevBundleByBlock {BestBlockNumber = blockTree.BestSuggestedHeader?.Number ?? 0};
            _bundles = new BundleSortedPool(
                _mevConfig.BundlePoolSize,
                _compareMevBundleByBlock.ThenBy(CompareMevBundleByMinTimestamp.Default),
                logManager ); 
            
            if (_finalizationManager != null)
            {
                _finalizationManager.BlocksFinalized += OnBlocksFinalized;
            }
        }

        private void RegisterNewBlockTracking()
        {
            switch (_mevConfig.SimulationMode)
            {
                case SimulationMode.NewHead:
                    _blockTree.NewHeadBlock += OnNewBlock;
                    break;
                case SimulationMode.NewBestSuggested:
                    _blockTree.NewSuggestedBlock += OnNewBlock;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_mevConfig.SimulationMode));
            }
        }

        public Task<IEnumerable<MevBundle>> GetBundles(BlockHeader parent, UInt256 timestamp, long gasLimit, CancellationToken token = default) => 
            Task.FromResult(GetBundles(parent.Number + 1, timestamp, token));

        public IEnumerable<MevBundle> GetBundles(long blockNumber, UInt256 timestamp, CancellationToken token = default) => 
            GetBundles(blockNumber, timestamp, timestamp, token);

        private IEnumerable<MevBundle> GetBundles(long blockNumber, UInt256 minTimestamp, UInt256 maxTimestamp, CancellationToken token = default)
        {
            if (_bundles.TryGetBucket(blockNumber, out MevBundle[] bundles))
            {
                foreach (MevBundle mevBundle in bundles)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    bool bundleIsInFuture = mevBundle.MinTimestamp != UInt256.Zero && minTimestamp < mevBundle.MinTimestamp;
                    bool bundleIsTooOld = mevBundle.MaxTimestamp != UInt256.Zero && maxTimestamp > mevBundle.MaxTimestamp;
                    if (!bundleIsInFuture && !bundleIsTooOld) 
                    {
                        yield return mevBundle;
                    }
                }
            }
                    
        }

        public bool AddBundle(MevBundle bundle)
        {
            if (ValidateBundle(bundle))
            {
                bool result;

                lock (_bundles)
                {
                    result = _bundles.TryInsert(bundle, bundle);
                }

                if (result)
                {
                    SimulateBundle(bundle);
                }

                return result;
            }

            return false;
        }

        private bool ValidateBundle(MevBundle bundle)
        {
            if (_finalizationManager?.IsFinalized(bundle.BlockNumber) == true)
            {
                return false;
            }

            UInt256 currentTimestamp = _timestamper.UnixTime.Seconds;

            if (bundle.MaxTimestamp < bundle.MinTimestamp)
            {
                if (_logger.IsDebug) _logger.Debug($"Bundle rejected, because {nameof(bundle.MaxTimestamp)} {bundle.MaxTimestamp} is < {nameof(bundle.MinTimestamp)} {bundle.MinTimestamp}.");
                return false;
            }
            else if (bundle.MaxTimestamp != 0 && bundle.MaxTimestamp < currentTimestamp)
            {
                if (_logger.IsDebug) _logger.Debug($"Bundle rejected, because {nameof(bundle.MaxTimestamp)} {bundle.MaxTimestamp} is < current {currentTimestamp}.");
                return false;
            }
            else if (bundle.MinTimestamp != 0 && bundle.MinTimestamp > currentTimestamp + _mevConfig.BundleHorizon)
            {
                if (_logger.IsDebug) _logger.Debug($"Bundle rejected, because {nameof(bundle.MinTimestamp)} {bundle.MaxTimestamp} is further into the future than accepted horizon {_mevConfig.BundleHorizon}.");
                return false;
            }

            return true;
        }

        private void SimulateBundle(MevBundle bundle)
        {
            ChainLevelInfo? level = _blockTree.FindLevel(bundle.BlockNumber - 1);
            if (level is not null)
            {
                for (int i = 0; i < level.BlockInfos.Length; i++)
                {
                    BlockHeader? header = _blockTree.FindHeader(level.BlockInfos[i].BlockHash, BlockTreeLookupOptions.None);
                    if (header is not null)
                    {
                        SimulateBundle(bundle, header);
                    }
                }
            }
        }
              
        private void SimulateBundle(MevBundle bundle, BlockHeader parent)
        {
            Keccak parentHash = parent.Hash!;
            ConcurrentDictionary<MevBundle, SimulatedMevBundleContext> blockDictionary = 
                _simulatedBundles.GetOrAdd(parentHash, _ => new ConcurrentDictionary<MevBundle, SimulatedMevBundleContext>());

            SimulatedMevBundleContext context = new();
            if (blockDictionary.TryAdd(bundle, context))
            {
                context.Task = _simulator.Simulate(bundle, parent, context.CancellationTokenSource.Token);
            }
            
            /*lock (_bundles) //CAN REMOVE?
            {
                _bundles.TryGetValue(bundle, out MevBundle mevBundle);
                
                if (!BundleValue.BlockHashes.Contains(parentHash))
                {
                    BundleValue.BlockHashes.Add(parentHash);
                }
            }*/
        }
        
        private void OnNewBlock(object? sender, BlockEventArgs e)
        {
            long blockNumber = e.Block!.Number;
            ResortBundlesByBlock(blockNumber);

            if (_finalizationManager?.IsFinalized(blockNumber) != true)
            {
                Task.Run(() =>
                {
                    IEnumerable<MevBundle> bundles = GetBundles(e.Block.Number + 1, UInt256.MaxValue, UInt256.Zero);
                    foreach (MevBundle bundle in bundles)
                    {
                        SimulateBundle(bundle, e.Block.Header);
                    }
                });
            }
        }

        private void ResortBundlesByBlock(long newBlockNumber)
        {
            IEnumerable<long> Range(long startBlockNumber, long count)
            {
                for (long blockNumber = startBlockNumber; blockNumber < startBlockNumber + count; blockNumber++)
                {
                    yield return blockNumber;
                }
            }
            
            long previousBestSuggested = _compareMevBundleByBlock!.BestBlockNumber;
            long fromBlockNumber = Math.Min(newBlockNumber, previousBestSuggested);
            long blockDelta = Math.Abs(newBlockNumber - previousBestSuggested);
            _bundles.UpdateGroups(Range(fromBlockNumber, blockDelta), () => _compareMevBundleByBlock.BestBlockNumber = newBlockNumber);
        }

        private void OnBlocksFinalized(object? sender, FinalizeEventArgs e) //NEED TO ADD ANYTHING ELSE?
        {
            long maxFinalizedBlockNumber = e.FinalizedBlocks.Select(b => b.Number).Max();
            int count = _bundles.Count;
            int capacity = _mevConfig.BundlePoolSize;
            MevBundle[] bundleArray = _bundles.GetSnapshot();
            IEnumerable<MevBundle> finalizedBundles = bundleArray.Where(bundle => bundle.BlockNumber < maxFinalizedBlockNumber);
            foreach (MevBundle bundle in finalizedBundles)
            {
                IEnumerable<KeyValuePair<Keccak, ConcurrentDictionary<MevBundle, SimulatedMevBundleContext>>> relatedHashes =
                    _simulatedBundles.Where(kvp => kvp.Value.ContainsKey(bundle));
                foreach (var (_, value) in relatedHashes)
                {
                    value.Remove(bundle, out SimulatedMevBundleContext? context);
                }
            }
        }

        async Task<IEnumerable<SimulatedMevBundle>> ISimulatedBundleSource.GetBundles(BlockHeader parent, UInt256 timestamp, long gasLimit, CancellationToken token)
        {
            HashSet<MevBundle> bundles = (await GetBundles(parent, timestamp, gasLimit, token)).ToHashSet();
            
            Keccak parentHash = parent.Hash!;
            if (_simulatedBundles.TryGetValue(parentHash, out ConcurrentDictionary<MevBundle, SimulatedMevBundleContext>? simulatedBundlesForBlock))
            {
                IEnumerable<Task<SimulatedMevBundle>> resultTasks = simulatedBundlesForBlock
                    .Where(b => bundles.Contains(b.Key))
                    .Select(b => b.Value.Task)
                    .ToArray();

                await Task.WhenAny(Task.WhenAll(resultTasks), token.AsTask());

                return resultTasks
                    .Where(t => t.IsCompletedSuccessfully)
                    .Select(t => t.Result)
                    .Where(t => t.Success)
                    .Where(s => s.GasUsed <= gasLimit);
            }
            else
            {
                return Enumerable.Empty<SimulatedMevBundle>();
            }
        }

        public void Dispose()
        {
            _blockTree.NewSuggestedBlock -= OnNewBlock;
            _blockTree.NewHeadBlock -= OnNewBlock;
            
            if (_finalizationManager != null)
            {
                _finalizationManager.BlocksFinalized -= OnBlocksFinalized;
            }
        }
        
        private class MevBundleComparer : IComparer<MevBundle>
        {
            public static readonly MevBundleComparer Default = new();
            
            public int Compare(MevBundle? x, MevBundle? y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
            
                // block number increasing
                int blockNumberComparison = x.BlockNumber.CompareTo(y.BlockNumber);
                if (blockNumberComparison != 0) return blockNumberComparison;
            
                // min timestamp increasing
                int minTimestampComparison = x.MinTimestamp.CompareTo(y.MinTimestamp);
                if (minTimestampComparison != 0) return minTimestampComparison;
            
                // max timestamp decreasing
                int maxTimestampComparison = y.MaxTimestamp.CompareTo(x.MaxTimestamp);
                if (maxTimestampComparison != 0) return maxTimestampComparison;

                for (int i = 0; i < Math.Max(x.Transactions.Count, y.Transactions.Count); i++)
                {
                    Keccak? xHash = x.Transactions.Count > i ? x.Transactions[i].Hash : null;
                    if (xHash is null) return -1;
                    
                    Keccak? yHash = y.Transactions.Count > i ? y.Transactions[i].Hash : null;
                    if (yHash is null) return 1;

                    int hashComparision = xHash.CompareTo(yHash);
                    if (hashComparision != 0) return hashComparision;
                }

                return 0;
            }
        }
        
        private class SimulatedMevBundleContext : IDisposable
        {
            public CancellationTokenSource CancellationTokenSource { get; } = new();
            public Task<SimulatedMevBundle> Task { get; set; } = null!;

            public void Dispose()
            {
                CancellationTokenSource.Dispose();
            }
        }
    }
}