using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGEthRpc
{
    /// <summary>
    /// Simple Wrapper for Ethereum GETH Http RPC api (jsonrpc v2)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC  and https://github.com/ethereum/go-ethereum/wiki/Management-APIs#personal_sendtransaction
    /// </summary>
    public partial class GethRpcProxy
    {
       

        public async Task<string[]> Personal_ListAccounts()
        {
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"personal_listAccounts\",\"params\":[],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<string[]>(rpcReq);
            return res;
        }


        public async Task<bool> Personal_UnlockAccountAsync(string accountAddress,string passphrase,int duration=300)
        {
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"personal_unlockAccount\",\"params\":[ \""+accountAddress+"\",\""+passphrase+"\"," + duration +" ],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }



    }
}
