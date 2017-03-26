using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.DataModel
{

    public class JsonRpcResult<ResultT> : IGethApiObject
    {
        [JsonProperty("jsonrpc")]
        public string RpcVersion { get; set; }

        [JsonProperty("result")]
        public ResultT Result { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("error")]
        public JsonRpcResultError Error { get; set; }
    }


    class JsonRpcResult : JsonRpcResult<string>
    { }
}
