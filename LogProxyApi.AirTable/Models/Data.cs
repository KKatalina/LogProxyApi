using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace LogProxyApi.AirTable.Models
{
    public class Data
    {
        [JsonProperty("records")]
        public Record[] Records { get; set; }

        [JsonProperty("offset")]
        public string Offset { get; set; }
    }
}
