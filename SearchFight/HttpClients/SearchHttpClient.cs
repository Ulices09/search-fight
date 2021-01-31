using SearchFight.Core.Models;
using SearchFight.HttpClients.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            var url = "https://www.google.com/search?q=" + query;
            var html = await httpClient.GetStringAsync(url);
            
            // Fake result
            int total = GetFakeResult();
            return total;
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
