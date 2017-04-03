using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.Api
{

    /// <summary>
    /// Encapsulation of DB rpc api for Geth
    /// Not intended to be used in a standalone instance (instance created by GethRpcProxy class)
    /// based on https://github.com/ethereum/wiki/wiki/JSON-RPC 
    /// </summary>
    public class GethRpcDbApi : JsonRpcBase
    {
        internal GethRpcDbApi(Uri endpoint) 
            : base(endpoint)
        {

        }


        /// <summary>
        /// NOT TESTED 
        /// Stores a string in the local database.
        /// </summary>
        /// <param name="databaseName">Database name.</param>
        /// <param name="keyName">Key name.</param>
        /// <param name="value">String to store</param>
        /// <returns>true if the value was stored, otherwise false.</returns>
        public async Task<bool> PutStringAsync(string databaseName, string keyName, string value)
        {
            //TODO : TO TEST
            string rpcReq = BuildRpcRequest("db_putString", databaseName, keyName, value);
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED
        /// Returns string from the local database.
        /// </summary>
        /// <param name="databaseName">Database name.</param>
        /// <param name="keyName">Key name.</param>
        /// <returns>the retrieved string</returns>
        public async Task<string> GetStringAsync(string databaseName, string keyName)
        {
            //TODO : TO TEST
            string rpcReq = BuildRpcRequest("db_getString", databaseName, keyName);
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// Stores a hexString in the local database.
        /// </summary>
        /// <param name="databaseName">Database name.</param>
        /// <param name="keyName">Key name.</param>
        /// <param name="hexvalue">hexString value to store</param>
        /// <returns>true if the value was stored, otherwise false.</returns>
        public async Task<bool> PutHexAsync(string databaseName, string keyName, string hexvalue)
        {
            // TODO : TO TEST
            string rpcReq = BuildRpcRequest("db_putHex", databaseName, keyName, hexvalue);
            var res = await ExecuteRpcRequestAsync<bool>(rpcReq);
            return res;
        }

        /// <summary>
        /// NOT TESTED 
        /// Returns hexString from the local database.
        /// </summary>
        /// <param name="databaseName">Database name.</param>
        /// <param name="keyName">Key name.</param>
        /// <returns>the retrieved hexString</returns>
        public async Task<string> GetHexAsync(string databaseName, string keyName)
        {
            // TODO : TO TEST
            string rpcReq = BuildRpcRequest("db_getHex", databaseName, keyName);
            var res = await ExecuteRpcRequestAsync<string>(rpcReq);
            return res;
        }
    }
}
