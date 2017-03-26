using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.DataModel
{
    public class TransactionReceipt : IGethApiObject
    {
        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }

        [JsonProperty("transactionIndex")]
        public string TransactionIndex { get; set; }

        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockNumber")]
        public string BlockNumber { get; set; }



        [JsonProperty("cumulatedGasUsed")]
        public string CumulatedGasUsed { get; set; }

        [JsonProperty("gasUsed")]
        public string GasUsed { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("logs")]
        public List<string> Logs { get; set; } // TODO : check serialization of this field


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
