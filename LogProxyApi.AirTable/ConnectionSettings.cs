using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace LogProxyApi.AirTable
{
    public static class ConnectionSettings
    {
        private static string ApiKey = "key46INqjpp7lMzjd";

        private static string BaseUrl = "https://api.airtable.com/v0/appD1b1YjWoXkUJwR";///Messages?maxRecords=3";

        public static string AppendParams(string baseUrl, Dictionary<string, string> queryParams)
        {
            if (queryParams == null || baseUrl == null)
                return baseUrl;

            var urlBuilder = new StringBuilder();

            foreach (var pair in queryParams)
            {
                if (pair.Value == null)
                    continue;

                if (urlBuilder.Length == 0)
                    urlBuilder.Append("?");
                else
                    urlBuilder.Append("&");

                urlBuilder.Append($"{HttpUtility.UrlEncode(pair.Key)}={HttpUtility.UrlEncode(pair.Value)}");
            }

            return baseUrl + urlBuilder.ToString();
        }

        public static string MessagesUrl
        {
            get 
            {
                return BaseUrl + "/Messages";
            }
        }

        public static void AddToken(HttpClient httpClient)
        {
            if (httpClient != null)
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
        }
    }
}
