using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// Encapsulation of WEB3 rpc api for Geth
    /// Not intended to be used in a standalone instance (instance created by GethRpcProxy class)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC 
    /// </summary>
    public class GethRpcWeb3Api : JsonRpcBase
    {
        internal GethRpcWeb3Api(Uri endpoint) 
            : base(endpoint)
        {

        }

        public async Task<string> GetClientVersionAsync()
        {
            string rpcReq = BuildRpcRequest("web3_clientVersion");
            return await ExecuteRpcRequestAsync(rpcReq);
        }

        public async Task<string> GetSha3Async(string data)
        {
            string rpcReq = BuildRpcRequest("web3_sha3",data);
            return await ExecuteRpcRequestAsync(rpcReq);
        }

    }
}
