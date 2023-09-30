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
        private string UriString { get; set; }

        public Client(string uri = "")
        {
            UriString = uri;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetScheduleHtml()
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                "https://www.nstu.ru/studies/schedule/schedule_classes/schedule?group=%D0%90%D0%92%D0%A2-113");

            using HttpResponseMessage response = await _httpClient.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();

            _httpClient.Dispose();

            return content;
        }
    }
}
