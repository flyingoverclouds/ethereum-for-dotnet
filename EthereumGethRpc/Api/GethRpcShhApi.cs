using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// NOT FULLY IMPLEMENTED AND/OR TESTED !!!!!
    /// 
    /// Encapsulation of SHH rpc api for Geth 
    /// Not intended to be used in a standalone instance (instance created by GethRpcProxy class)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC 
    /// </summary>
    public class GethRpcShhApi : JsonRpcBase
    {
        internal GethRpcShhApi(Uri endpoint) 
            : base(endpoint)
        {

        }


        /// <summary>
        /// NOT TESTED 
        /// Returns the current whisper protocol version.
        /// </summary>
        /// <returns>current whisper protocol version</returns>
        public async Task<string> GetVersion()
        {
            // TODO : TEST

            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"shh_version\",\"params\":[ ],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="topics"></param>
        /// <param name="payload"></param>
        /// <param name="priority"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<string> Post(string from, string to, string[] topics, string payload, string priority, string ttl)
        {
            // TODO : TEST
            throw new NotImplementedException("ShhPost");
            //string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"shh_version\",\"params\":[ ],\"id\":" + GetNewId().ToString() + "}";
            //var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            //return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// Creates new whisper identity in the client.
        /// </summary>
        /// <returns>address of the new identiy</returns>
        public async Task<string> NewIdentity()
        {
            // TODO : to test
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"shh_newIdentity\",\"params\":[ ],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// Checks if the client hold the private keys for a given identity.
        /// </summary>
        /// <param name="address">identity address to check</param>
        /// <returns>true if the client holds the privatekey for that identity, otherwise false.</returns>
        public async Task<bool> HasIdentity(string address)
        {
            // TODO : to test
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"shh_hasIdentity\",\"params\":[ \"" + address + "\" ],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// </summary>
        /// <returns>address of the new group</returns>
        public async Task<string> NewGroup()
        {
            // TODO : to test
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"shh_newGroup\",\"params\":[  ],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// </summary>
        /// <param name="address">identity address to add to a group (?).</param>
        /// <returns>true if the identity was successfully added to the group, otherwise false (?).</returns>
        public async Task<bool> AddToGroup(string address)
        {
            // TODO : to test
            string rpcReq = "{ \"jsonrpc\":\"2.0\",\"method\":\"shh_addToGroup\",\"params\":[ \"" + address + "\" ],\"id\":" + GetNewId().ToString() + "}";
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

        // TODO : shh_newFilter

        // TODO : shh_uninstallFilter

        // TODO : shh_getFilterChanges

        // TODO : shh_getMessages

        // TODO : shh_newFilter
    }
}
