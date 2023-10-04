using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.WebClient
{
    internal class Client
    {
        private HttpClient _httpClient;
        public string UriString { get; private set; }

        public Client(string uri)
        {
            UriString = uri;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetHtml()
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, UriString);

            using HttpResponseMessage response = await _httpClient.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();

            _httpClient.Dispose();

            return content;
        }
    }
}
