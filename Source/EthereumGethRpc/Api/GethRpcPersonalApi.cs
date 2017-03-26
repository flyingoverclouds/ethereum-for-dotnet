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
            string rpcReq = BuildRpcRequest("personal_listAccounts");
            var res = await ExecuteRpcRequestAsync<string[]>(rpcReq);
            return res;
        }


        /// <summary>
        /// Unlock account address. 
        /// </summary>
        /// <param name="accountAddress">account address to unlock</param>
        /// <param name="passphrase">password/passphrase </param>
        /// <param name="duration">duration of unlock (in seconds)</param>
        /// <returns></returns>
        public async Task<bool> UnlockAccountAsync(string accountAddress, string passphrase, int duration = 300)
        {
            string rpcReq = BuildRpcRequest("personal_unlockAccount", accountAddress, passphrase, duration);
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

    }
}
