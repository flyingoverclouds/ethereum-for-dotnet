using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.DataModel
{
    /// <summary>
    /// contains data available in a block of the blockchaine. 
    /// WARNING : NOT FULLY IMPLEMENTED : does not support details transaction
    /// </summary>
    public class Block : IGethApiObject
    {
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }
        [JsonProperty("extraData")]
        public string ExtraData { get; set; }
        [JsonProperty("gasLimit")]
        public string GasLimit { get; set; }
        [JsonProperty("gasUsed")]
        public string GasUsed { get; set; }
        [JsonProperty("hash")]
        public string Hash { get; set; }
        [JsonProperty("logsBloom")]
        public string LogsBloom { get; set; }
        [JsonProperty("miner")]
        public string Miner { get; set; }
        [JsonProperty("mixHash")]
        public string MixHash { get; set; }
        [JsonProperty("nonce")]
        public string Nonce { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("parentHash")]
        public string ParentHash { get; set; }
        [JsonProperty("receiptsRoot")]
        public string ReceiptsRoot { get; set; }
        [JsonProperty("sha3Uncles")]
        public string Sha3Uncles { get; set; }
        [JsonProperty("size")]
        public string Size { get; set; }
        [JsonProperty("stateRoot")]
        public string StateRoot { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("totalDifficulty")]
        public string TotalDifficulty { get; set; }

        /// <summary>
        /// Transactions proeprty does not support details transactions
        /// </summary>
        [JsonProperty("transactions")]
        public string[] Transactions { get; set; }
        [JsonProperty("transactionsRoot")]
        public string TransactionsRoot { get; set; }
        [JsonProperty("uncles")]
        public string[] Uncles { get; set; }
    }
}
