using EthereumGethRpc.DataModel;
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

        /// <summary>
        /// Start JSON RPC listening on the GETH instance
        /// </summary>
        /// <param name="host">network interface to open the listener socket on (defaults to "localhost")</param>
        /// <param name="port">network port to open the listener socket on (defaults to 8545)</param>
        /// <param name="cors">cross-origin resource sharing header to use (defaults to "")</param>
        /// <param name="apis">API modules to offer over this interface (defaults to "eth,net,web3")</param>
        /// <returns>true if opened and listening, false otherwise</returns>
        public async Task<bool> StartRpcAsync(string host="localhost",string port="8545",string cors="",string apis = "eth,net,web3")
        {
            string rpcReq = BuildRpcRequest("admin_startRpc", host, port, cors, apis);
            return await ExecuteRpcRequestAsync<bool>(rpcReq);
        }

        /// <summary>
        /// Stop the JSON? RPC listener on the GETH Instance
        /// </summary>
        /// <returns>true if stopped, false otherwise</returns>
        public async Task<bool> StopRpcAsync()
        {
            string rpcReq = BuildRpcRequest("admin_stopRpc");
            return await ExecuteRpcRequestAsync<bool>(rpcReq);
        }


        /// <summary>
        /// starts an WebSocket based JSON RPC API webserver on the GETH instance
        /// </summary>
        /// <param name="host">network interface to open the listener socket on (defaults to  "localhost" )</param>
        /// <param name="port">network port to open the listener socket on (defaults to  8546 )</param>
        /// <param name="cors">cross-origin resource sharing header to use (defaults to  "" )</param>
        /// <param name="apis">API modules to offer over this interface (defaults to  "eth,net,web3" )</param>
        /// <returns></returns>
        public async Task<bool> StartWsAsync(string host = "localhost", string port = "8546", string cors = "", string apis = "eth,net,web3")
        {
            string rpcReq = BuildRpcRequest("admin_startWS", host, port, cors, apis);
            return await ExecuteRpcRequestAsync<bool>(rpcReq);
        }


        /// <summary>
        /// Stop the websocket listener on the GETH Instance
        /// </summary>
        /// <returns>true if stopped, false otherwise</returns>
        public async Task<bool> StopWsAsync()
        {
            string rpcReq = BuildRpcRequest("admin_stopWS");
            return await ExecuteRpcRequestAsync<bool>(rpcReq);
        }

        /// <summary>
        ///    NOT IMPLEMENTED : Throw NotImplementedException
        /// return general information about the geth node instance + specific information per supported protocol. 
        /// </summary>
        /// <returns>NodeInfo object</returns>
        public async Task<NodeInfo> GetNodeInfoAsync()
        {
            throw new NotImplementedException("admin_nodeInfo call not implemented");
        }

        /// <summary>
        ///    NOT IMPLEMENTED : Throw NotImplementedException
        /// return general information about connected nodes + specific information per supported protocol. 
        /// </summary>
        /// <returns>array of PeerInfo object</returns>
        public async Task<PeerInfo[]> GetPeersAsync()
        {
            throw new NotImplementedException("admin_peers call not implemented");
        }

    }
}
