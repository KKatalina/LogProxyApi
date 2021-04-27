using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LogProxyApi.Web.Tests
{
    public class MapperUtilityTests
    {
        [Fact]
        public void MessageMapper()
        {
            var fields = new Common.Models.Message()
            {
                Id = "SomeId",
                Text = "Some message",
                Title = "Test summary",
                ReceivedAt = DateTime.Now.AddHours(-2)
            };
            var message = fields.MapEx();

            Assert.IsType<Models.Message>(message);
            Assert.Equal(fields.Title, message.Title);
            Assert.Equal(fields.Text, message.Text);
            Assert.Equal(fields.ReceivedAt, message.ReceivedAt);
            Assert.Equal(fields.Id, message.Id);
        }
    }
}
