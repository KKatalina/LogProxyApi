using LogProxyApi.Web.Models;
using System;
using System.Threading.Tasks;
using LogProxyApi.Common.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace LogProxyApi.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        IRepository _repository;
        public MessagesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<Message> CreateMessageAsync([FromBody] Message newMessage)
        {
            //newMessage.Id = "testsss";
            //return await Task.FromResult(newMessage);
            var result = await _repository.SaveMessageAsync(newMessage.Title, newMessage.Text, DateTime.UtcNow);
            return result.MapEx();
        }

        [HttpGet]
        public async Task<Message[]> GetMessagesAsync()
        {
            var result = await _repository.GetMessagesAsync(null);
            return result.Select(msg => msg.MapEx()).ToArray();
        }
    }
}
