using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Table.Queryable;
using System.Collections.Generic;

namespace NutritionTracker.Functions
{
    [StorageAccount("NutritionTrackerStorage")]
    public static class GetRestaurantMenus
    {
        [FunctionName("GetRestaurantMenus")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequestMessage req, [Table("RestaurantMenus")] CloudTable restaurantMenusTable, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var queryParams = req.GetQueryNameValuePairs();
            // parse query parameter
            string restaurantName = queryParams
                .FirstOrDefault(q => string.Compare(q.Key, "restaurantName", true) == 0)
                .Value;

            // Get request body
            //dynamic data = await req.Content.ReadAsAsync<object>();

            // Set name to query string or body data
            //restaurantName = restaurantName ?? data?.name;

            if (restaurantName == null) {
                return req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a restaurant name on the query string");
            }

            var restaurantQuery = restaurantMenusTable
                .CreateQuery<RestaurantFoodItem>()
                .Where(r => r.PartitionKey == restaurantName).AsTableQuery();

            var restaurantFoodItems = new List<RestaurantFoodItem>();
            TableContinuationToken continuationToken = null;
            do
            {
                // Execute the query async until there is no more result
                var queryResult = await restaurantQuery.ExecuteSegmentedAsync(continuationToken);
                restaurantFoodItems.AddRange(queryResult);

                continuationToken = queryResult.ContinuationToken;
            } while (continuationToken != null);


            var returnData = JsonConvert.SerializeObject(restaurantFoodItems);

            return req.CreateResponse(HttpStatusCode.OK, restaurantFoodItems,"application/json");
        }

        public class RestaurantFoodItem : TableEntity
        {
            public RestaurantFoodItem() { }
            public RestaurantFoodItem(string restaurantName,string foodName)
            {
                PartitionKey = restaurantName;
                RowKey = foodName;
            }
            public double ServingPoints { get; set; }
        }
    }
}
