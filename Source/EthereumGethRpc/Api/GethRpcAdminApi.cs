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

        /// <summary>
        /// Return the current datadir used by the GETH instance
        /// </summary>
        /// <returns>current datadir</returns>
        public async Task<string> GetDataDirAsync()
        {
            string rpcReq = BuildRpcRequest("admin_datadir");
            return await ExecuteRpcRequestAsync(rpcReq);
        }

        /// <summary>
        /// Add a new peer connection to the current GETH isntance. 
        /// Allow your geth to join an ethereum network. 
        /// </summary>
        /// <param name="enodeUri">enode of gethinstance to add</param>
        /// <returns>true if addPeed surceeded</returns>
        public async Task<bool> AddPeerAsync(string enodeUri)
        {
            string rpcReq = BuildRpcRequest("admin_addPeer", enodeUri);
            return await ExecuteRpcRequestAsync<bool>(rpcReq);
        }

        /// <summary>
        /// Define the folder where the solidity compiler is installed
        /// </summary>
        /// <param name="solidityCompilerLocation">fullpath to solidity compiler</param>
        /// <returns>true if succeeded, false otherwise.</returns>
        public async Task<bool> SetSolcAsync(string solidityCompilerLocation)
        {
            string rpcReq = BuildRpcRequest("admin_setSolc", solidityCompilerLocation);
            return await ExecuteRpcRequestAsync<bool>(rpcReq);
        }
    }
}
