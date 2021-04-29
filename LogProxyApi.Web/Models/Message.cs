using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogProxyApi.Web.Models
{
    /// <summary>
    /// Log message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Mesage id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Message title.
        /// </summary>
        [JsonProperty("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Message text.
        /// </summary>
        [JsonProperty("Text")]
        public string Text { get; set; }

        /// <summary>
        /// Timestamp when the message was received.
        /// </summary>
        [JsonProperty("receivedAt")]
        public DateTime? ReceivedAt { get; set; }
    }
}
