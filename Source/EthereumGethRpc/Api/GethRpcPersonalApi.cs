using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// Encapsulation of PERSONAL rpc api for Geth
    /// Not intended to be used in a standalone instance (instance created by GethRpcProxy class)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC  and https://github.com/ethereum/go-ethereum/wiki/Management-APIs#personal_sendtransaction
    /// </summary>
    public class GethRpcPersonalApi : JsonRpcBase
    {
        internal GethRpcPersonalApi(Uri endpoint) 
            : base(endpoint)
        {

        }
        public async Task<string> GetDataDirAsync()
        {
            string rpcReq = BuildRpcRequest("admin_datadir");
            return await ExecuteRpcRequestAsync(rpcReq);
        }


        public async Task<string[]> ListAccountsAsync()
        {
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"personal_listAccounts\",\"params\":[],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<string[]>(rpcReq);
            return res;
        }


        public async Task<bool> UnlockAccountAsync(string accountAddress, string passphrase, int duration = 300)
        {
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"personal_unlockAccount\",\"params\":[ \"" + accountAddress + "\",\"" + passphrase + "\"," + duration + " ],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

    }
}
