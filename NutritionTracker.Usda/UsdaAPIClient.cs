using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NutritionTracker.Usda
{
    public class UsdaAPIClient
    {
        private HttpClient Client { get; set; }
        private string ApiKey { get; set; }
        /// <summary>
        /// TODO Make this mockable for unit testing. HttpClient is NOT mockable like this
        /// see https://stackoverflow.com/questions/36425008/mocking-httpclient-in-unit-tests#
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="apiKey"></param>
        public UsdaAPIClient(HttpClient httpClient, string apiKey)
        {
            Client = httpClient;
            ApiKey = apiKey;
        }

        public async Task<UsdaSearch> Search(string query, int offset = 0, int max = 1500, string sortOrder = "n", string dataFormat = "json")
        {
            var url = $"https://api.nal.usda.gov/ndb/search/?format={dataFormat}&q={query}&sort={sortOrder}&max={max}&offset={offset}&api_key={ApiKey}";
            var response = await Client.GetAsync(url);
            var stringResult = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<UsdaSearch>(stringResult);
            return searchResult;
        }
    }
}
