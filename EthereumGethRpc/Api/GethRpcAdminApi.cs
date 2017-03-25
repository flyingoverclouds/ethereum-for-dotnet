using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// Encapsulation of ADMIN rpc api for Geth
    /// Not intended to be used in a standalone instance (instance created by GethRpcProxy class)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC 
    /// </summary>
    public class GethRpcAdminApi : JsonRpcBase
    {
        internal GethRpcAdminApi(Uri endpoint) 
            : base(endpoint)
        {

        }
        public async Task<string> GetDataDir()
        {
            string rpcReq = BuildRpcRequest("admin_datadir");
            return await ExecuteRpcRequestAsync(rpcReq);
        }

    }
}
