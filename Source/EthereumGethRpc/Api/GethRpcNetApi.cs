using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// Encapsulation of NET rpc api for Geth
    /// Not intended to be used in a standalone instance (instance created by GethRpcProxy class)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC 
    /// </summary>
    public class GethRpcNetApi : JsonRpcBase
    {
        internal GethRpcNetApi(Uri endpoint) 
            : base(endpoint)
        {

        }

        public async Task<string> GetVersion()
        {
            string rpcReq = BuildRpcRequest("net_version");
            return await ExecuteRpcRequestAsync(rpcReq);
        }

        public async Task<bool> IsListening()
        {
            string rpcReq = BuildRpcRequest("net_listening");
            var result = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return result;
        }

        /// <summary>
        /// Return peer count 
        /// </summary>
        /// <returns></returns>
        public async Task<Int64> GetPeerCount()
        {
            // TODO : implement bignumber 

            string rpcReq = BuildRpcRequest("net_peerCount");
            var result = await ExecuteRpcRequestAsync(rpcReq);
            return Int64FromQuantity(result);
        }


    }
}
