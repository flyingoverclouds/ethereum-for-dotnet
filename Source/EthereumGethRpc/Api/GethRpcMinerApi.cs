using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// Encapsulation of MINER rpc api for Geth
    /// Not intended to be used as a standalone instance (instance created by GethRpcProxy class ctor)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC  and  https://github.com/ethereum/go-ethereum/wiki/Management-APIs
    /// </summary>
    public class GethRpcMinerApi : JsonRpcBase
    {
        internal GethRpcMinerApi(Uri endpoint) 
            : base(endpoint)
        {
        }
        

        /// <summary>
        /// Start mining
        /// </summary>
        /// <param name="threadCount">number of thread. (0 or neg = auto)</param>
        /// <returns>true if mining is started, false otherwise.</returns>
        public async Task<bool> StartAsync(int threadCount = -1)
        {
            string rpcReq;
            if (threadCount <= 0)
                rpcReq = BuildRpcRequest("miner_start");
            else
                rpcReq = BuildRpcRequest("miner_start",threadCount);
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

        /// <summary>
        /// Stop mining
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StopAsync()
        {
            string rpcReq = BuildRpcRequest("miner_stop");
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }


    }
}
