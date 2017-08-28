using System;
using System.Collections.Generic;

namespace NutritionTracker.Usda
{
    
    public class UsdaSearchItem
    {
        public int offset { get; set; }
        public string group { get; set; }
        public string name { get; set; }
        public string ndbno { get; set; }
        public string ds { get; set; }
    }

    public class UsdaSearchList
    {
        public string q { get; set; }
        public string sr { get; set; }
        public string ds { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int total { get; set; }
        public string group { get; set; }
        public string sort { get; set; }
        public List<UsdaSearchItem> item { get; set; }
    }

    /// <summary>
    /// https://ndb.nal.usda.gov/ndb/doc/apilist/API-SEARCH.md
    /// </summary>
    public class UsdaSearch
    {
        public UsdaSearchList list { get; set; }
    }
}
