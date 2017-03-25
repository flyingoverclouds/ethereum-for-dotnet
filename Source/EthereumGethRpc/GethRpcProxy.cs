using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc
{
    /// <summary>
    /// Simple Wrapper for Ethereum GETH Http RPC api (jsonrpc v2)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC and https://github.com/ethereum/wiki/wiki/JavaScript-API
    /// </summary>
    public partial class GethRpcProxy : EthereumGethRpc.JsonRpcBase
    {
        public GethRpcProxy(Uri rpcEndpoint)
            :base(rpcEndpoint)
        {
            this.Eth = new EthereumGethRpc.Api.GethRpcEthApi(rpcEndpoint);
            this.Admin = new EthereumGethRpc.Api.GethRpcAdminApi(rpcEndpoint);
            this.Miner = new EthereumGethRpc.Api.GethRpcMinerApi(rpcEndpoint);
            this.Net = new EthereumGethRpc.Api.GethRpcNetApi(rpcEndpoint);
            this.Shh = new EthereumGethRpc.Api.GethRpcShhApi(rpcEndpoint);
            this.Personal = new EthereumGethRpc.Api.GethRpcPersonalApi(rpcEndpoint);
        }
        
        /// <summary>
        /// Access to ETH api of Geth
        /// </summary>
        public EthereumGethRpc.Api.GethRpcEthApi Eth{ get; private set; }

        /// <summary>
        /// Access to ADMIN api of Geth
        /// </summary>
        public EthereumGethRpc.Api.GethRpcAdminApi Admin{ get; private set; }

        /// <summary>
        /// Access to MINER api of Geth
        /// </summary>
        public EthereumGethRpc.Api.GethRpcMinerApi Miner { get; private set; }

        /// <summary>
        /// Access to NET api of Geth
        /// </summary>
        public EthereumGethRpc.Api.GethRpcNetApi Net { get; private set; }

        /// <summary>
        /// Access to SHH api of Geth
        /// </summary>
        public EthereumGethRpc.Api.GethRpcShhApi Shh { get; private set; }


        /// <summary>
        /// Access to PERSONAL api of Geth
        /// </summary>
        public EthereumGethRpc.Api.GethRpcPersonalApi Personal { get; private set; }


        /// <summary>
        /// Access to WEB3 api of Geth
        /// </summary>
        public EthereumGethRpc.Api.GethRpcWeb3Api Web3 { get; private set; }

        /// <summary>
        /// Return activated API module with version
        /// </summary>
        /// <returns>Dictionnary<string,string> : key is module name, value is module version</string></returns>
        public async Task<Dictionary<string,string>> GetModules()
        {
            string rpcReq = BuildRpcRequest("rpc_modules");
            var res = await ExecuteRpcRequestAsync<Dictionary<string, string>>(rpcReq);
            return res;
        }


    }
}
