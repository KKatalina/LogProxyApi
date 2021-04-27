using System;
using System.Collections.Generic;
using System.Text;

namespace LogProxyApi.Common.Models
{
    public class Message
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime ReceivedAt { get; set; }
    }
}
