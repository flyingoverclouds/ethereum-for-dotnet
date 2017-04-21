using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// NOT FULLY IMPLEMENTED AND/OR TESTED !!!!!
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
        public async Task<string> GetVersionAsync()
        {
            // TODO : TEST
            string rpcReq = BuildRpcRequest("shh_version");
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT IMPLEMENTED (throw NotImplementException)
        /// send a whisper messaged
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="topics"></param>
        /// <param name="payload"></param>
        /// <param name="priority"></param>
        /// <param name="ttl"></param>
        /// <returns></returns>
        public async Task<string> PostAsync(string from, string to, string[] topics, string payload, string priority, string ttl)
        {
            // TODO : TEST
            throw new NotImplementedException("shh_post call not implemented");

            //string rpcReq = BuildRpcRequest("shh_post", from, to, topics, payload, priority, ttl); 
            //var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            //return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// Creates new whisper identity in the client.
        /// </summary>
        /// <returns>address of the new identiy</returns>
        public async Task<string> NewIdentityAsync()
        {
            // TODO : to test
            string rpcReq = BuildRpcRequest("shh_newIdentity");
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// Checks if the client hold the private keys for a given identity.
        /// </summary>
        /// <param name="address">identity address to check</param>
        /// <returns>true if the client holds the privatekey for that identity, otherwise false.</returns>
        public async Task<bool> HasIdentityAsync(string address)
        {
            // TODO : to test
            string rpcReq = BuildRpcRequest("shh_hasIdentity",address);
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// </summary>
        /// <returns>address of the new group</returns>
        public async Task<string> NewGroupAsync()
        {
            // TODO : to test
            string rpcReq = BuildRpcRequest("shh_newGroup");
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// </summary>
        /// <param name="address">address to add to a group.</param>
        /// <returns>true if the identity was successfully added to the group, otherwise false (?).</returns>
        public async Task<bool> AddToGroupAsync(string address)
        {
            // TODO : to test
            string rpcReq = BuildRpcRequest("shh_addToGroup",address);
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT IMPLEMENTED (thow NotImplementedException)
        /// Creates filter to notify, when client receives whisper message matching the filter options
        /// </summary>
        /// <param name="filterOptions"></param>
        /// <returns>filter ID</returns>
        public async Task<bool> NewFilterAsync(string  filterOptions)
        {
            throw new NotImplementedException("shh_newFilter call not implemented");
            // TODO : to IMPLEMENT
            //string rpcReq = BuildRpcRequest("shh_addToGroup", filterOptions);
            //var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            //return res;
        }

        /// <summary>
        /// NOT TESTED
        /// uninstall a filter using its filter ID
        /// </summary>
        /// <param name="filterId">filterid to uninstall</param>
        /// <returns>true if uninstall succeeded, false otherwise</returns>
        public async Task<bool> UninstallFilterAsync(string filterId)
        {
            // TODO : to TEST 
            string rpcReq = BuildRpcRequest("shh_uninstallFilter", filterId);
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }


        /// <summary>
        /// NOT IMPLEMENTED (thow NotImplementedException)
        /// return changes mathing the filter
        /// </summary>
        /// <param name="filterId">id of filter to query</param>
        /// <returns>changes</returns>
        public async Task<string> GetFilterChangesAsync(string filterId)
        {
            throw new NotImplementedException("shh_getFilterChanges call not implemented");
            // TODO : to IMPLEMENT
            //string rpcReq = BuildRpcRequest("shh_getFilterChanges", filterId);
            //var res = await ExecuteRpcRequestAsync(rpcReq);
            //return res;
        }

        /// <summary>
        /// NOT IMPLEMENTED (thow NotImplementedException)
        /// return last messages for the filter
        /// </summary>
        /// <param name="filterId"></param>
        /// <returns></returns>
        public async Task<string> GetMessagesAsync(string filterId)
        {
            throw new NotImplementedException("shh_getMessages call not implemented");
            // TODO : to test
            string rpcReq = BuildRpcRequest("shh_getMessages", filterId);
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }

    }
}
