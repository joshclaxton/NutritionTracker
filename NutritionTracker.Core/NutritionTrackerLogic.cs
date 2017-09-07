using NutritionTracker.Usda;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NutritionTracker.Core
{
    public class NutritionTrackerLogic
    {
        private HttpClient httpClient;
        private string usdaApiKey;
        private UsdaAPIClient usdaApiClient;
        public NutritionTrackerLogic(HttpClient httpClient, string usdaApiKey)
        {
            this.httpClient = httpClient;
            this.usdaApiKey = usdaApiKey;
            this.usdaApiClient = new UsdaAPIClient(httpClient, usdaApiKey);
        }
        public async Task<List<string>> GetRestaurantMenus(string restaurantName)
        {
            var searchItems = new List<UsdaSearchItem>();
            var searchResults = await usdaApiClient.SearchAll(restaurantName);
            var foods = await usdaApiClient.GetFoods(searchResults.Select(m => m.NutritionDatabaseNumber));
            //todo
            //group by manufacturer
            //perform points calculation
            //follow rate limits at https://api.data.gov/docs/rate-limits/
            return foods.Select(m => m.FoodReportDetail.FoodName).ToList();
            
        }
    }
}
