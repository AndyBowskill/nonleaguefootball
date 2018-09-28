using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NonLeague.Services
{
    public class APIClient
    {
        public static HttpClient Client { get; set; }

        static APIClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://www.footballwebpages.co.uk/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
