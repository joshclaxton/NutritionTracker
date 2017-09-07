using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using NutritionTracker.Core;
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

            if (restaurantName == null)
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass restaurantName on the query string");

            var usdaApiKey = System.Environment.GetEnvironmentVariable("UsdaApiKey");
            
            //can use HttpClient Overload to mock HttpClient 
            //http://chimera.labs.oreilly.com/books/1234000001708/ch14.html#_fake_response_handlers
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://api.nal.usda.gov/ndb/V2/reports?ndbno=45183692&ndbno=45183702&type=f&format=json&api_key=RpfS42WSIs4Pmj9jxY1Q18tMYTz1dCVtPJpChNRY");
                var stringResult = await response.Content.ReadAsStringAsync();

                var nutritionTrackerLogic = new NutritionTrackerLogic(httpClient, usdaApiKey);
                var restaurantMenus = await nutritionTrackerLogic.GetRestaurantMenus(restaurantName);
                return req.CreateResponse(HttpStatusCode.OK, restaurantMenus);
            }

            
        }
    }
}
