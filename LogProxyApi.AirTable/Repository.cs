using LogProxyApi.AirTable.Models;
using LogProxyApi.Common.Interfaces;
using LogProxyApi.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LogProxyApi.AirTable
{
    public class Repository : IRepository
    {
        public async Task<Message[]> GetMessagesAsync(Paginator paginator = null)
        {
            using (var client = new HttpClient())
            {
                ConnectionSettings.AddToken(client);
                var queryParams = new Dictionary<string, string>();
                if (paginator != null)
                {
                    if (paginator.PageSize.HasValue)
                        queryParams.Add("pageSize", paginator.PageSize.ToString());
                    if (!string.IsNullOrEmpty(paginator.OffsetId))
                        queryParams.Add("offset", paginator.OffsetId);
                }

                if (queryParams.Count == 0)
                {
                    // TODO: extract all async
                }

                var url = ConnectionSettings.AppendParams(ConnectionSettings.MessagesUrl, queryParams);

                using (var response = await client.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Data>(responseBody);
                    return result.Records.Where(record => record != null).Select(record => MapperUtility.Mapper.Map<Message>(record.Fields)).ToArray();
                }
            }
        }

        public async Task<Message> SaveMessageAsync(string title, string text, DateTime received)
        {
            var data = new Data()
            {
                Records = new Record[]
                {
                    new Record(){
                        Fields =
                            new Fields(){
                            Id = Guid.NewGuid().ToString(),
                            Message = text,
                            Summary = title,
                            ReceivedAt = received.Kind == DateTimeKind.Local ? received.ToUniversalTime() : received
                        }
                    }
                }
            };

            using (var client = new HttpClient())
            {
                ConnectionSettings.AddToken(client);
                var content = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                using (var result = await client.PostAsync(ConnectionSettings.MessagesUrl, httpContent))
                {
                    result.EnsureSuccessStatusCode();
                    var resultBody = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<Data>(resultBody);
                    return data.Records.First().Fields.MapEx();
                }
            }
        }
    }
}
