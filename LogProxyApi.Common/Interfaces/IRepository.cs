using LogProxyApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogProxyApi.Common.Interfaces
{
    public interface IRepository
    {
        Task<Message> SaveMessageAsync(string titel, string text, DateTime received);
        Task<Message[]> GetMessagesAsync(Paginator paginator = null);
    }
}
