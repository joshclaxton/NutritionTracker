using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionTracker.Usda
{
    
    public class FoodReportDesc
    {
        public string ndbno { get; set; }
        public string name { get; set; }
        public string sd { get; set; }
        public string fg { get; set; }
        public string sn { get; set; }
        public string cn { get; set; }
        public string manu { get; set; }
        public double nf { get; set; }
        public double cf { get; set; }
        public double ff { get; set; }
        public double pf { get; set; }
        public string r { get; set; }
        public string rd { get; set; }
        public string ds { get; set; }
        public string ru { get; set; }
    }

    public class FoodReportNutrient
    {
        public int nutrient_id { get; set; }
        public string name { get; set; }
        public string group { get; set; }
        public string unit { get; set; }
        public double value { get; set; }
        public string derivation { get; set; }
        public object sourcecode { get; set; }
        public object dp { get; set; }
        public string se { get; set; }
        public List<object> measures { get; set; }
    }

    public class FoodReportSource
    {
        public int id { get; set; }
        public string title { get; set; }
        public string authors { get; set; }
        public string vol { get; set; }
        public string iss { get; set; }
        public string year { get; set; }
    }

    public class FoodReportFood
    {
        public string sr { get; set; }
        public string type { get; set; }
        public FoodReportDesc desc { get; set; }
        public List<FoodReportNutrient> nutrients { get; set; }
        public List<FoodReportSource> sources { get; set; }
        public List<object> footnotes { get; set; }
        public List<object> langual { get; set; }
    }

    public class FoodReportFoodMetaData
    {
        public FoodReportFood food { get; set; }
        public string error { get; set; }
    }

    /// <summary>
    /// https://ndb.nal.usda.gov/ndb/doc/apilist/API-FOOD-REPORTV2.md
    /// </summary>
    public class UsdaFoodReport
    {
        public List<FoodReportFoodMetaData> foods { get; set; }
        public int count { get; set; }
        public int notfound { get; set; }
        public double api { get; set; }
    }
}
