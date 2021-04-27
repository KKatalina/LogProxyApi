using LogProxyApi.Common.Interfaces;
using LogProxyApi.Common.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LogProxyApi.Web.Tests
{
    public class MessagesControllerTests
    {
        [Fact]
        public async Task CreateMessageTestAsync()
        {
            var expected = new Message()
            {
                Id = "Id1",
                ReceivedAt = DateTime.UtcNow,
                Text = "Text1",
                Title = "Title1"
            };

            var mock = new Mock<IRepository>();
            mock.Setup(m => m.SaveMessageAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                   .Returns<string, string, DateTime>((title, text, date) =>
                               {
                                   return Task.FromResult(new Message()
                                   {
                                       Id = expected.Id,
                                       ReceivedAt = date,
                                       Text =text,
                                       Title = title
                                   }); 
                               });
            var controller = new MessagesController(mock.Object);
            var result = await controller.CreateMessageAsync(new Models.Message() { Title = expected.Title, Text = expected.Text });
            Assert.IsType<Models.Message>(result);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.Title, result.Title);
            Assert.Equal(expected.Text, result.Text);
            Assert.NotNull(result.ReceivedAt);
            Assert.Equal(expected.ReceivedAt, result.ReceivedAt.Value, TimeSpan.FromSeconds(2));
        }

        [Fact]
        public async Task GetMessagesTestAsync()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(p => p.GetMessagesAsync(null)).Returns(GetTestMessages());

            var controller = new MessagesController(mock.Object);
            var result = await controller.GetMessagesAsync();
            var expected = await GetTestMessages();
            Assert.Equal(expected.Length, result.Length);
            for (var i = 0; i < expected.Length; i++)
            {
                var expectedMsg = expected[i];
                var resultMsg = result[i];

                Assert.Equal(expectedMsg.Id, resultMsg.Id);
                Assert.Equal(expectedMsg.Title, resultMsg.Title);
                Assert.Equal(expectedMsg.Text, resultMsg.Text);
                Assert.Equal(expectedMsg.ReceivedAt, resultMsg.ReceivedAt);
            }
        }

        private Task<Message[]> GetTestMessages()
        {
            return Task.FromResult(new Message[] { 
                new Message(){ Id = "Id1", ReceivedAt = new DateTime(2020, 1, 1, 12, 45, 23, DateTimeKind.Utc), Text="Text1", Title = "Title1"},
                new Message(){ Id = "Id2", ReceivedAt = new DateTime(2020, 4, 1, 12, 45, 23, DateTimeKind.Utc), Text="Text2", Title = "Title2"},
                new Message(){ Id = "Id3", ReceivedAt = new DateTime(2020, 5, 1, 12, 45, 23, DateTimeKind.Utc), Text="Text3", Title = "Title2"}
            });
        }
    }
}
