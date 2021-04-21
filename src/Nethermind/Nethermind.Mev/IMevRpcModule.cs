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

using Nethermind.Blockchain.Find;
using Nethermind.JsonRpc;
using Nethermind.JsonRpc.Modules;
using Nethermind.JsonRpc.Data;
using Nethermind.Int256;

namespace Nethermind.Mev
{
    // ReSharper disable once ClassNeverInstantiated.Global

    [RpcModule(ModuleType.Mev)]
    public interface IMevRpcModule : IRpcModule
    {        
        [JsonRpcMethod(Description = "Adds bundle to the tx pool.", IsImplemented = true)]
        ResultWrapper<bool> eth_sendBundle(TransactionForRpc[] transactions, UInt256 blockNumber, UInt256 minTimestamp, UInt256 maxTimestamp);
        
        [JsonRpcMethod(Description = "Simulates the bundle behaviour.", IsImplemented = true)]
        ResultWrapper<TxToResult> eth_callBundle(TransactionForRpc[] transactionCalls, BlockParameter blockParameter, UInt256? timestamp);
    }
}
