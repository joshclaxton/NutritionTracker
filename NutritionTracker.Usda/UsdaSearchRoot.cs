using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NutritionTracker.Usda
{
    /// <summary>
    /// Individual item returned by USDA Search results
    /// </summary>
    public class UsdaSearchItem
    {
        /// <summary>
        /// Offset index for this search item
        /// </summary>
        [JsonProperty(PropertyName = "offset")]
        public int OffsetIndex { get; set; }
        /// <summary>
        /// Food group to which the food belongs
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public string FoodGroup { get; set; }
        /// <summary>
        /// The food’s name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string FoodName { get; set; }
        /// <summary>
        /// The food’s NDB Number
        /// </summary>
        [JsonProperty(PropertyName = "ndbno")]
        public string NutritionDatabaseNumber { get; set; }
        /// <summary>
        /// Data source: BL=Branded Food Products or SR=Standard Release
        /// </summary>
        [JsonProperty(PropertyName = "ds")]
        public string DataSource { get; set; }
    }

    /// <summary>
    /// Meta data for the USDA Search results
    /// </summary>
    public class UsdaSearch
    {
        /// <summary>
        /// terms requested and used in the search
        /// </summary>
        [JsonProperty(PropertyName = "q")]
        public string Query { get; set; }
        /// <summary>
        /// Standard Release version of the data being reported
        /// </summary>
        [JsonProperty(PropertyName = "sr")]
        public string ReleaseVersion { get; set; }
        /// <summary>
        /// Data source: BL=Branded Food Products or SR=Standard Release
        /// </summary>
        [JsonProperty(PropertyName = "ds")]
        public string DataSource { get; set; }
        /// <summary>
        /// Beginning item in the list
        /// </summary>
        [JsonProperty(PropertyName = "start")]
        public int StartOffset { get; set; }
        /// <summary>
        /// Last item in the list
        /// </summary>
        [JsonProperty(PropertyName = "end")]
        public int EndOffset { get; set; }
        /// <summary>
        /// Total # of items returned by the search
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int TotalItems { get; set; }
        /// <summary>
        /// Food group to which the food belongs
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public string FoodGroup { get; set; }
        /// <summary>
        /// Requested sort order (r=relevance or n=name)
        /// </summary>
        [JsonProperty(PropertyName = "sort")]
        public string SortOrder { get; set; }
        /// <summary>
        /// List of search items
        /// </summary>
        [JsonProperty(PropertyName = "item")]
        public List<UsdaSearchItem> SearchItems { get; set; }
    }

    /// <summary>
    /// High level container for USDA Search results
    /// https://ndb.nal.usda.gov/ndb/doc/apilist/API-SEARCH.md
    /// </summary>
    public class UsdaSearchRoot
    {
        /// <summary>
        /// Meta data for the USDA Search results
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        public UsdaSearch UsdaSearch { get; set; }
    }
}
