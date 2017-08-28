using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionTracker.Usda
{
    public class UsdaListItem
    {
        public int offset { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class UsdaList
    {
        public string lt { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int total { get; set; }
        public string sr { get; set; }
        public string sort { get; set; }
        public List<UsdaListItem> item { get; set; }
    }

    /// <summary>
    /// https://ndb.nal.usda.gov/ndb/doc/apilist/API-LIST.md
    /// </summary>
    public class UsdaListRoot
    {
        public UsdaList list { get; set; }
    }
}
