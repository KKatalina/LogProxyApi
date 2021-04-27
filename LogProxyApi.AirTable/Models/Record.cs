using Newtonsoft.Json;
using System;

namespace LogProxyApi.AirTable.Models
{
    public class Record
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        [JsonProperty("createdTime")]
        public DateTime? CreatedTime { get; set; }
    }
}
