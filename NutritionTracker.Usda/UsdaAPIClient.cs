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
        private const int searchMaxBatchSize = 1500;
        private const int getFoodsMaxBatchSize = 50;
        private HttpClient httpClient { get; set; }
        private string usdaApiKey { get; set; }
        /// <summary>
        /// TODO Make this mockable for unit testing. HttpClient is NOT mockable like this
        /// see https://stackoverflow.com/questions/36425008/mocking-httpclient-in-unit-tests#
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="apiKey"></param>
        public UsdaAPIClient(HttpClient httpClient, string apiKey)
        {
            this.httpClient = httpClient;
            this.usdaApiKey = apiKey;
        }

        public async Task<List<UsdaSearchItem>> SearchAll(string query,string sortOrder = "n", string dataFormat = "json")
        {
            var searchItems = new List<UsdaSearchItem>();
            var firstBatch = await SearchSingleBatch(query, sortOrder:sortOrder, dataFormat: dataFormat);
            searchItems.AddRange(firstBatch.SearchItems);

            var numberOfCalls = (firstBatch.TotalItems - firstBatch.EndOffset) / (double)firstBatch.EndOffset;
            var offset = 0;
            for (var i = 0; i < numberOfCalls; i++)
            {
                offset += searchMaxBatchSize;
                var nextBatch = await SearchSingleBatch(query, offset:offset, sortOrder: sortOrder, dataFormat: dataFormat);
                searchItems.AddRange(nextBatch.SearchItems);
            }

            return searchItems;
        }

        private async Task<UsdaSearch> SearchSingleBatch(string query, int offset = 0, int max = searchMaxBatchSize, string sortOrder = "n", string dataFormat = "json")
        {
            if (max > searchMaxBatchSize || searchMaxBatchSize < 1)
                throw new ArgumentOutOfRangeException(nameof(max), $"must be 1 to {searchMaxBatchSize}");
            var url = $"https://api.nal.usda.gov/ndb/search/?format={dataFormat}&q={query}&sort={sortOrder}&max={max}&offset={offset}&api_key={usdaApiKey}";
            var response = await httpClient.GetAsync(url);
            var stringResult = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<UsdaSearchRoot>(stringResult);
            return searchResult.UsdaSearch;
        }

        public async Task<List<FoodReportFood>> GetFoods(IEnumerable<string> nutritionDatabaseNumbers, string reportType = "f", string dataFormat = "json")
        {
            var foods = new List<FoodReportFood>();
            var batchSize = getFoodsMaxBatchSize;
            while (nutritionDatabaseNumbers.Any())
            {
                var batch = nutritionDatabaseNumbers.Take(batchSize);
                nutritionDatabaseNumbers = nutritionDatabaseNumbers.Skip(batchSize);
                var foodReport = await GetFoodsSingleBatch(batch, reportType, dataFormat);
                foods.AddRange(foodReport.FoodList.Select(m => m.Food));
            }
            return foods;
        }

        private async Task<UsdaFoodReport> GetFoodsSingleBatch(IEnumerable<string> nutritionDatabaseNumbers, string reportType = "f", string dataFormat = "json")
        {
            var count = nutritionDatabaseNumbers?.Count();
            if (count > getFoodsMaxBatchSize || count < 1)
                throw new ArgumentOutOfRangeException(nameof(nutritionDatabaseNumbers), count, $"must be 1 to {getFoodsMaxBatchSize}");

            var nutrionDatabaseNumbersParameter = string.Join("&ndbno=", nutritionDatabaseNumbers);
            var url = $"https://api.nal.usda.gov/ndb/V2/reports?ndbno={nutrionDatabaseNumbersParameter}&type={reportType}&format={dataFormat}&api_key={usdaApiKey}";
            var response = await httpClient.GetAsync(url);
            var stringResult = await response.Content.ReadAsStringAsync();
            var foodReport = JsonConvert.DeserializeObject<UsdaFoodReport>(stringResult);
            return foodReport;
        }
    }
}
