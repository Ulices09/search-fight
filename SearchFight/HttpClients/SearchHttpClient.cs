using SearchFight.Core.Models;
using SearchFight.HttpClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace SearchFight.HttpClients
{
    public class SearchHttpClient : ISearchHttpClient
    {
        private readonly HttpClient httpClient;
        private readonly Configuration configuration;

        public SearchHttpClient(HttpClient httpClient, Configuration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<int> GetGoogleResults(string programmingLanguage)
        {
            var query = HttpUtility.UrlEncode(programmingLanguage);
            var url = $"https://www.googleapis.com/customsearch/v1?key={configuration.GoogleSearchApiKey}&cx={configuration.GoogleSearchEngineId}&start=1&q={query}";
            var response = await httpClient.GetAsync(url);
            
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GoogleSearchResponse>(content);
                return Convert.ToInt32(data.SearchInformation.totalResults);
            }

            throw new Exception("Goole Search API error");
        }

        public async Task<int> GetBingResults(string programmingLanguage)
        {
            var query = HttpUtility.UrlEncode(programmingLanguage);
            var url = "https://www.bing.com/search?q=" + query;
            var html = await httpClient.GetStringAsync(url);
            
            // Fake result
            int total = GetFakeResult();
            return total;
        }

        private int GetFakeResult()
        {
            Random random = new Random();
            int total = random.Next(0, 10000000);
            return total;
        }
    }
}
