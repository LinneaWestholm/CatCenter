using CatCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatCenter.Data
{
    internal class CatApi
    {
        private readonly HttpClient _httpClient;

        public CatApi()
        {
            _httpClient = HttpClientFactory.CreateHttpClient();
        }

        public async Task<string> GetRandomCatImageAsync()
        {
            var response = await _httpClient.GetAsync("images/search");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var images = JsonSerializer.Deserialize<List<CatImage>>(responseString);

                return images?.FirstOrDefault()?.Url ?? throw new InvalidOperationException("No image URL found.");
            }

            throw new HttpRequestException("Failed to fetch cat image.");

        }
    }
}
