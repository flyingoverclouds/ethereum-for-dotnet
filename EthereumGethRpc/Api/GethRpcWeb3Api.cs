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

        public async Task<string> GetClientVersion()
        {
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"web3_clientVersion\",\"params\":[],\"id\":" + GetNewId().ToString() + "}";
            return await ExecuteRpcRequestAsync(rpcReq);
        }

        public async Task<string> GetSha3(string data)
        {
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"web3_sha3\",\"params\":[\"" + data + "\"],\"id\":" + GetNewId().ToString() + "}";
            return await ExecuteRpcRequestAsync(rpcReq);
        }

    }
}
