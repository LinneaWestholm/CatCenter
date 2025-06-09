using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatCenter.Data
{
    internal class HttpClientFactory
    {
        // Singleton HttpClient
        private static readonly HttpClient _httpClient = new HttpClient();

        static HttpClientFactory()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.thecatapi.com/v1/")
            };

        }
        public static HttpClient CreateHttpClient()
        {
            return _httpClient;
        }
    }
}
