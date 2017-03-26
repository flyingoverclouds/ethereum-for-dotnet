using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumGethRpc.DataModel
{
    public class SyncingStatus : IGethApiObject
    {
        [JsonProperty("startingBlock")]
        public string StartingBlock { get; set; }

        [JsonProperty("currentBlock")]
        public string CurrentBlock { get; set; }

        [JsonProperty("highestBlock")]
        public string HighestBlock { get; set; }

        public override string ToString()
        {
            return $"StartingBlock={StartingBlock} CurrentBlock={CurrentBlock} HighestBlock={HighestBlock}";
        }
    }
}
