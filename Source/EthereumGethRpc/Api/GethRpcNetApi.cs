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
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"net_version\",\"params\":[],\"id\":" + GetNewId().ToString() + "}";
            return await ExecuteRpcRequestAsync(rpcReq);
        }

        public async Task<bool> IsListening()
        {
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"net_listening\",\"params\":[],\"id\":" + GetNewId().ToString() + "}";
            var result = await ExecuteRpcRequestAsync(rpcReq);
            return Convert.ToBoolean(result);
        }

        /// <summary>
        /// HACK / Should be replaced by usage of a big number library
        /// </summary>
        /// <returns></returns>
        public async Task<Int64> GetPeerCount()
        {
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"net_peerCount\",\"params\":[],\"id\":" + GetNewId().ToString() + "}";
            var result = await ExecuteRpcRequestAsync(rpcReq);
            return Int64FromQuantity(result);
        }


    }
}
