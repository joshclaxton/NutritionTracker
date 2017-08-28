using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table.Queryable;

namespace NutritionTracker.Data
{
    public class RestaurantMenusTable
    {
        private static async Task<List<RestaurantFoodItem>> GetRestaurantFoodItems(CloudTable restaurantMenusTable, string restaurantName)
        {
            var restaurantQuery = restaurantMenusTable
                            .CreateQuery<RestaurantFoodItem>()
                            .Where(r => r.PartitionKey == restaurantName)
                            .AsTableQuery();

            var restaurantFoodItems = new List<RestaurantFoodItem>();
            TableContinuationToken continuationToken = null;
            do
            {
                var queryResult = await restaurantQuery.ExecuteSegmentedAsync(continuationToken);
                restaurantFoodItems.AddRange(queryResult);

                continuationToken = queryResult.ContinuationToken;
            } while (continuationToken != null);
            return restaurantFoodItems;
        }

        public class RestaurantFoodItem : TableEntity
        {
            public RestaurantFoodItem() { }
            public RestaurantFoodItem(string restaurantName, string foodName)
            {
                PartitionKey = restaurantName;
                RowKey = foodName;
            }
            public double ServingPoints { get; set; }
        }
    }
}
