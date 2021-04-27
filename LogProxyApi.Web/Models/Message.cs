using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogProxyApi.Web.Models
{

    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("receivedAt")]
        public DateTime? ReceivedAt { get; set; }
    }
}
