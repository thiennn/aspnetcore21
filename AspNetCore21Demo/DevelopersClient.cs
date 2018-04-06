using AspNetCore21Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetCore21Demo
{
    public class DevelopersClient
    {
        private readonly HttpClient _httpClient;

        public DevelopersClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<Developer>> GetDevelopers()
        {
            var response = await _httpClient.GetAsync("api/developers");
            response.EnsureSuccessStatusCode();
            var developers = await response.Content.ReadAsAsync<List<Developer>>();
            return developers;
        }
    }
}
