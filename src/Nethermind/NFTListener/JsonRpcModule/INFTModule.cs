using System.Collections.Generic;
using Nethermind.Core.Crypto;
using Nethermind.JsonRpc;
using Nethermind.JsonRpc.Modules;

namespace NFTListener.JsonRpcModule
{
    [RpcModule(ModuleType.NFT)]
    public interface INFTModule : IModule
    {
        [JsonRpcMethod(IsImplemented = true, IsSharable = true)]
        ResultWrapper<IEnumerable<Keccak>> nft_lastTransactions();
    }
}