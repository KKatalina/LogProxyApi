using LogProxyApi.AirTable.Models;
using Newtonsoft.Json;
using System;
using Xunit;

namespace LogProxyApi.AirTable.Tests.Models
{
    public class RecordTests
    {
        [Fact]
        public void DataSerializeTest()
        {
            var fields = new AirTable.Models.Record()
            {
                Id = string.Empty,
                Fields = new Fields(),
                CreatedTime = DateTime.MinValue.ToUniversalTime()
            };

            var result = JsonConvert.SerializeObject(fields);
            Assert.Equal("{\"id\":\"\",\"fields\":{\"id\":null,\"Summary\":null,\"Message\":null,\"receivedAt\":null},\"createdTime\":\"0001-01-01T00:00:00Z\"}", result);
        }

        [Fact]
        public void DataDeserializeTest()
        {
            var result = JsonConvert.DeserializeObject<AirTable.Models.Record>("{\"id\":\"\",\"fields\":{},\"CreatedTime\":\"0001-01-01T00:00:00Z\"}");
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.Fields);
            Assert.NotNull(result.CreatedTime);
        }
    }
}
