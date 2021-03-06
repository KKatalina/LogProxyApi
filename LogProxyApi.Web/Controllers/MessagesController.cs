using LogProxyApi.Web.Models;
using System;
using System.Threading.Tasks;
using LogProxyApi.Common.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LogProxyApi.Web.Infrastructure;
using Microsoft.Extensions.Logging;

namespace LogProxyApi.Web.Controllers
{
    /// <summary>
    /// Messages controller.
    /// </summary>
    [BasicAuthentication]
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;
        private readonly IRepository _repository;

        public MessagesController(IRepository repository, ILogger<MessagesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Used to save log message.
        /// </summary>
        /// <param name="newMessage">Message to be saved.</param>
        /// <returns>Result message.</returns>
        [HttpPost]
        public async Task<Message> CreateMessageAsync([FromBody] Message newMessage)
        {
            var result = await _repository.SaveMessageAsync(newMessage.Title, newMessage.Text, DateTime.UtcNow);
            return result.MapEx();
        }

        /// <summary>
        /// Gets all available messages.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Message[]> GetMessagesAsync()
        {
            var result = await _repository.GetMessagesAsync(null);
            return result.Select(msg => msg.MapEx()).ToArray();
        }
    }
}
