using LogProxyApi.AirTable.Models;
using Newtonsoft.Json;
using System;
using Xunit;

namespace LogProxyApi.AirTable.Tests.Models
{
    public class FieldsTests
    {
        [Fact]
        public void FieldsSerializeTest()
        {
            var fields = new Fields()
            {
                Id = string.Empty,
                Message = string.Empty,
                ReceivedAt = DateTime.MinValue.ToUniversalTime(),
                Summary = string.Empty
            };

            var result = JsonConvert.SerializeObject(fields);
            Assert.Equal("{\"id\":\"\",\"Summary\":\"\",\"Message\":\"\",\"receivedAt\":\"0001-01-01T00:00:00Z\"}", result);
        }

        [Fact]
        public void FieldsDeserializeTest()
        {
            var result = JsonConvert.DeserializeObject<Fields>("{\"id\":\"\",\"Summary\":\"\",\"Message\":\"\",\"receivedAt\":\"0001-01-01T00:00:00Z\"}");
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.Message);
            Assert.NotNull(result.Summary);
            Assert.NotNull(result.ReceivedAt);
        }
    }
}
