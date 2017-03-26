using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.DataModel
{
    [JsonObject("error")]
    public class JsonRpcResultError : IGethApiObject
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        //{"jsonrpc":"2.0","id":2,"error":{"code":-32602,"message":"invalid argument 0: hex string has odd length"}}

}
}
