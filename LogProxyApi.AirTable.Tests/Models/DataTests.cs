using LogProxyApi.AirTable.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogProxyApi.AirTable.Tests.Models
{
    public class DataTests
    {
        [Fact]
        public void DataSerializeTest()
        {
            var data = new Data()
            {
                Records = new AirTable.Models.Record[0],
                Offset = string.Empty
            };

            var result = JsonConvert.SerializeObject(data);
            Assert.Equal("{\"records\":[],\"offset\":\"\"}", result);
        }

        [Fact]
        public void DataDeserializeTest()
        {
            var data = new Data()
            {
                Records = new AirTable.Models.Record[0],
                Offset = string.Empty
            };

            var result = JsonConvert.DeserializeObject<Data>("{\"records\":[],\"offset\":\"\"}");
            Assert.NotNull(result);
            Assert.NotNull(result.Offset);
            Assert.NotNull(result.Records);
        }
    }
}
