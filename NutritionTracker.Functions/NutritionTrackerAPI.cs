using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using NutritionTracker.Usda;
using System.Configuration;


namespace NutritionTracker.Functions
{
    
    public static class NutritionTrackerAPI
    {
        //[StorageAccount("NutritionTrackerStorage")]
        [FunctionName("GetRestaurantMenus")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequestMessage req, /*[Table("RestaurantMenus")] CloudTable restaurantMenusTable,*/ TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var queryParams = req.GetQueryNameValuePairs();
            // parse query parameter
            string restaurantName = queryParams
                .FirstOrDefault(q => string.Compare(q.Key, "restaurantName", true) == 0)
                .Value;

            if (restaurantName == null) return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass restaurantName on the query string");

            var apiKey = System.Environment.GetEnvironmentVariable("UsdaApiKey");

            using (var httpClient = new HttpClient()) {
                /// TODO Make this mockable for unit testing. HttpClient is NOT mockable like this
                /// see https://stackoverflow.com/questions/36425008/mocking-httpclient-in-unit-tests#
                var usdaApiClient = new UsdaAPIClient(httpClient,apiKey);
                var searchResult = await usdaApiClient.Search(restaurantName);
                return req.CreateResponse(HttpStatusCode.OK, searchResult);
            }

            //todo lets just use their API to start with. If I get throttled, I can build more infrastructure (hourly job plus azure table)
            //search by restaurant name https://ndb.nal.usda.gov/ndb/doc/apilist/API-SEARCH.md
            //group by manufacturer
            //call https://ndb.nal.usda.gov/ndb/doc/apilist/API-FOOD-REPORTV2.md for all food items in the search with the MANUFACTURER (50 per request)
            //perform points calculation
            //follow rate limits at https://api.data.gov/docs/rate-limits/
        }
    }
}
