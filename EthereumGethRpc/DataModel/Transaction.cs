using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.DataModel
{
    public class Transaction
    {
        /// <summary>
        /// Sender account address
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Target account address
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }


        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockNumber")]
        public string BlockNumber { get; set; }

        [JsonProperty("transactionIndex")]
        public string TransactionIndex { get; set; }
       
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("gas")]
        public string Gas { get; set; }

        [JsonProperty("gasPrice")]
        public string GasPrice { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        /// <summary>
        /// ABI of contract attached to the transaction
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
