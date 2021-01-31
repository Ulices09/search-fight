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
            var url = $"https://api.bing.microsoft.com/v7.0/search?q={query}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", configuration.BingSearchApiKey);
            var response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BingSearchResponse>(content);
                return data.WebPages.TotalEstimatedMatches;
            }

            throw new Exception("Bing Search API error");
        }
    }
}
