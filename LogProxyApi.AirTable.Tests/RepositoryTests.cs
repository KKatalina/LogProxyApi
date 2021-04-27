using LogProxyApi.Common.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LogProxyApi.AirTable.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public async Task GetMessagesAsync()
        {
            var repository = new Repository();
            var result  = await repository.GetMessagesAsync(new Paginator() { PageSize=3});
            Assert.IsType<Message[]>(result);
            Assert.Equal(3, result.Length);
        }

        [Fact]
        public async Task SaveMessageAsync()
        {
            const string title = "Test_title";
            const string text = "Test_text";
            var repository = new Repository();
            var receivedDate = DateTime.Now.AddDays(-1).ToUniversalTime(); 
            var newMessage = await repository.SaveMessageAsync(title, text, receivedDate);
            Assert.IsType<Message>(newMessage);
            Assert.Equal(title, newMessage.Title);
            Assert.Equal(text, newMessage.Text);
            Assert.Equal(receivedDate, newMessage.ReceivedAt, TimeSpan.FromMilliseconds(1));
            Assert.False(string.IsNullOrWhiteSpace(newMessage.Id), "Id is null or empty.");
        }
    }
}
