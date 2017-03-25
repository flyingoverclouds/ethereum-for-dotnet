using EthereumGethRpc.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc
{
    /// <summary>
    /// This is the abstract base class for all JsonRpc based api class. 
    /// It contains common and generic function needed/used to call Geth Rpc API. 
    /// </summary>
    public abstract class JsonRpcBase 
    {
        private Uri nodeUri = null;

        public JsonRpcBase(Uri web3endpoint)
        {
            this.nodeUri = web3endpoint;
        }

        #region JSONRPC request id generator
        private long currentId = 0;
        private object idLock = new object();

        protected long GetNewId()
        {
            lock (idLock)
            {
                return ++currentId;
            }
        }

        #endregion

        /// <summary>
        /// this function buil the json request for a specific api call
        /// </summary>
        /// <param name="methodeName">name of the method to call </param>
        /// <param name="parameters">parameters to add in the request. string a directly added (" are escaped). if parameter is not a string, the json serializartion is inserted</param>
        /// <returns></returns>
        protected string BuildRpcRequest(string methodeName, params object[] parameters)
        {
            StringBuilder rpcReq = new StringBuilder();
            rpcReq.Append("{ \"jsonrpc\":\"2.0\",\"method\":\"");
            rpcReq.Append(methodeName);
            rpcReq.Append("\",\"params\":[");
            string str;
            for (int n = 0; n < parameters.Length; n++)
            {
                if (n > 0) // not on the 1st param -> add coma
                    rpcReq.Append(" , ");
                str = parameters[n] as string;
                if (str != null)
                    rpcReq.AppendFormat("\"{0}\"", str.Replace("\"", "\\\""));
                else
                    rpcReq.Append(parameters[n]);
            }
            rpcReq.Append("],\"id\": ");
            rpcReq.Append(GetNewId().ToString());
            rpcReq.Append("}");
            return rpcReq.ToString();
        }

        /// <summary>
        /// Call the RPC endpoint to execute a method call which return a string (or hextring)
        /// if call went wrong, or api return error result, a JsonRpcException is thrown.
        /// </summary>
        /// <param name="rpcReq">rpc request to execute</param>
        /// <returns></returns>
        protected async Task<string> ExecuteRpcRequestAsync(string rpcReq)
        {
            return await ExecuteRpcRequestAsync<string>(rpcReq);
        }

        /// <summary>
        /// Call the RPC endpoint to execute a method call which return a json object(or hextring)
        /// if call went wrong, or api return error result, a JsonRpcException is thrown.
        /// </summary>
        /// <typeparam name="ResultT">type of object return by the call </typeparam>
        /// <param name="rpcReq">rpc request to execute</param>
        /// <returns>object deserializing from JSON </returns>
        protected async Task<ResultT> ExecuteRpcRequestAsync<ResultT>(string rpcReq)
        {
            var res = await CallJsonRPC(nodeUri, rpcReq);

            var rpccallresult = JsonConvert.DeserializeObject<JsonRpcResult<ResultT>>(res);
            if (rpccallresult.Error != null)
            {
                throw new JsonRpcException(rpccallresult.Error);
            }
            return rpccallresult.Result;
        }

        protected Int64 Int64FromQuantity(string qty)
        {
            if (qty.StartsWith("0x"))
                return Int64.Parse(qty.Substring(2), System.Globalization.NumberStyles.HexNumber);
            return Int64.Parse(qty);
        }


        /// <summary>
        /// Make the call. 
        /// </summary>
        /// <param name="nodeUri"></param>
        /// <param name="postPayload"></param>
        /// <returns></returns>
        private async Task<string> CallJsonRPC(Uri nodeUri, string postPayload)
        {
            var wr = System.Net.HttpWebRequest.CreateHttp(nodeUri);
            byte[] payload = Encoding.UTF8.GetBytes(postPayload);
            wr.Method = "POST";
            wr.ContentLength = payload.Length;
            Stream dataStream = wr.GetRequestStream();
            dataStream.Write(payload, 0, payload.Length);
            dataStream.Close();
            var resp = await wr.GetResponseAsync();
            Stream datastream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);
            string w3resp = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            return w3resp;
        }


    }
}
