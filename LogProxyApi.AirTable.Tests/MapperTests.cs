using LogProxyApi.AirTable.Models;
using LogProxyApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogProxyApi.AirTable.Tests
{
    public class MapperTests
    {
        [Fact]
        public void FieldsToMessage()
        {
            var fields = new Fields() {
                Id = "SomeId",
                Message = "Some message",
                Summary = "Test summary",
                ReceivedAt = DateTime.Now.AddHours(-2)
            };
            var message = fields.MapEx();

            Assert.IsType<Message>(message);
            Assert.Equal(fields.Summary, message.Title);
            Assert.Equal(fields.Message, message.Text);
            Assert.Equal(fields.ReceivedAt, message.ReceivedAt);
            Assert.Equal(fields.Id, message.Id);
        }
    }
}
