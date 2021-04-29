using LogProxyApi.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogProxyApi.Web.Tests.Models
{
    public class MessageTests
    {
        [Fact]
        public void MessageSerializeTest()
        {
            var fields = new Message()
            {
                Id = string.Empty,
                ReceivedAt = DateTime.MinValue.ToUniversalTime(),
                Text = string.Empty,
                Title = string.Empty
            };

            var result = JsonConvert.SerializeObject(fields);
            Assert.Equal("{\"id\":\"\",\"Title\":\"\",\"Text\":\"\",\"receivedAt\":\"0001-01-01T00:00:00Z\"}", result);
        }

        [Fact]
        public void MessageDeserializeTest()
        {
            var result = JsonConvert.DeserializeObject<Message>("{\"id\":\"\",\"Title\":\"\",\"Text\":\"\",\"receivedAt\":\"0001-01-01T00:00:00Z\"}");
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.Title);
            Assert.NotNull(result.Text);
            Assert.NotNull(result.ReceivedAt);
        }
    }
}
