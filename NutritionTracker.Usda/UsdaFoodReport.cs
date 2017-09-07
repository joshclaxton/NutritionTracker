using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionTracker.Usda
{
    public class FoodReportMeasure
    {
        /// <summary>
        /// Name of the measure, e.g. "large"
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
        /// <summary>
        /// Equivalent of the measure expressed as an eunit
        /// </summary>
        [JsonProperty(PropertyName = "eqv")]
        public double EquivalentEUnits { get; set; }
        /// <summary>
        /// Unit in which the equivalent amount is expressed. Usually either gram (g) or milliliter (ml)
        /// </summary>
        [JsonProperty(PropertyName = "eunit")]
        public string EUnits { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        [JsonProperty(PropertyName = "qty")]
        public double Quantity { get; set; }
        /// <summary>
        /// Gram equivalent value of the measure
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public double GramEquivalent { get; set; }
    }

    /// <summary>
    /// Ingredients (Branded Food Products report only)
    /// </summary>
    public class Ingredients
    {
        /// <summary>
        /// List of ingredients
        /// </summary>
        [JsonProperty(PropertyName = "desc")]
        public string desc { get; set; }
        /// <summary>
        /// Date ingredients were last updated by company
        /// </summary>
        [JsonProperty(PropertyName = "upd")]
        public string upd { get; set; }
    }
    public class FoodReportDetail
    {
        /// <summary>
        /// NDB food number
        /// </summary>
        [JsonProperty(PropertyName = "ndbno")]
        public string NutritionDatabaseNumber { get; set; }
        /// <summary>
        /// Food name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string FoodName { get; set; }
        /// <summary>
        /// Short Description
        /// </summary>
        [JsonProperty(PropertyName = "sd")]
        public string ShortDescription { get; set; }
        /// <summary>
        /// Unknown
        /// </summary>
        [JsonProperty(PropertyName = "fg")]
        public string fg { get; set; }
        /// <summary>
        /// Scientific name
        /// </summary>
        [JsonProperty(PropertyName = "sn")]
        public string ScientificName { get; set; }
        /// <summary>
        /// Commercial name
        /// </summary>
        [JsonProperty(PropertyName = "cn")]
        public string CommercialName { get; set; }
        /// <summary>
        /// Manufacturer
        /// </summary>
        [JsonProperty(PropertyName = "manu")]
        public string Manufacturer { get; set; }
        /// <summary>
        /// Nitrogen to protein conversion factor
        /// </summary>
        [JsonProperty(PropertyName = "nf")]
        public double NitrogenToProteinConversionFactor { get; set; }
        /// <summary>
        /// Carbohydrate factor
        /// </summary>
        [JsonProperty(PropertyName = "cf")]
        public double CarbohydrateFactor { get; set; }
        /// <summary>
        /// Fat factor
        /// </summary>
        [JsonProperty(PropertyName = "ff")]
        public double FatFactor { get; set; }
        /// <summary>
        /// Protein factor
        /// </summary>
        [JsonProperty(PropertyName = "pf")]
        public double ProteinFactor { get; set; }
        /// <summary>
        /// Refuse %
        /// </summary>
        [JsonProperty(PropertyName = "r")]
        public string RefusePercent { get; set; }
        /// <summary>
        /// Refuse description
        /// </summary>
        [JsonProperty(PropertyName = "rd")]
        public string RefuseDescription { get; set; }
        /// <summary>
        /// Database source: 'Branded Food Products' or 'Standard Reference'
        /// </summary>
        [JsonProperty(PropertyName = "ds")]
        public string DataSource { get; set; }
        /// <summary>
        /// Reporting unit: nutrient values are reported in this unit, usually gram (g) or milliliter (ml)
        /// </summary>
        [JsonProperty(PropertyName = "ru")]
        public string ReportingUnit { get; set; }
    }

    /// <summary>
    /// Metadata elements for each nutrient included in the food report
    /// </summary>
    public class FoodReportNutrient
    {
        /// <summary>
        /// Nutrient number (nutrient_no) for the nutrient
        /// </summary>
        [JsonProperty(PropertyName = "nutrient_id")]
        public int NutrientNumber { get; set; }
        /// <summary>
        /// Nutrient name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string NutrientName { get; set; }
        /// <summary>
        /// Nutrient Group
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public string NutrientGroup { get; set; }
        /// <summary>
        /// Unit of measure for this nutrient
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// 100 g equivalent value of the nutrient
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public double OneHundredGramEquivalent { get; set; }
        /// <summary>
        /// Indicator of how the value was derived
        /// </summary>
        [JsonProperty(PropertyName = "derivation")]
        public string Derivation { get; set; }
        ///// <summary>
        ///// This can be either an array of int or a string...Ignore for now
        ///// </summary>
        //[JsonProperty(PropertyName = "sourcecode")]
        //public object sourcecode { get; set; }
        ///// <summary>
        ///// Number of data points
        ///// </summary>
        //[JsonProperty(PropertyName = "dp")]
        //public object NumberOfDataPoints { get; set; }
        /// <summary>
        /// Standard error
        /// </summary>
        [JsonProperty(PropertyName = "se")]
        public string StandardError { get; set; }
        /// <summary>
        /// List of measures reported for a nutrient
        /// </summary>
        [JsonProperty(PropertyName = "measures")]
        public List<FoodReportMeasure> Measures { get; set; }
    }

    /// <summary>
    /// Reference source, usually a bibliographic citation, for the food
    /// </summary>
    public class FoodReportSource
    {
        [JsonProperty(PropertyName = "id")]
        public int SourceId { get; set; }
        /// <summary>
        /// name of reference
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// authors of the report
        /// </summary>
        [JsonProperty(PropertyName = "authors")]
        public string Authors { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty(PropertyName = "vol")]
        public string Volume { get; set; }
        /// <summary>
        ///Iissue
        /// </summary>
        [JsonProperty(PropertyName = "iss")]
        public string Issue { get; set; }
        /// <summary>
        /// Publication year
        /// </summary>
        [JsonProperty(PropertyName = "year")]
        public string PublicationYear { get; set; }
        /// <summary>
        /// Start Page
        /// </summary>
        [JsonProperty(PropertyName = "start")]
        public string StartPage { get; set; }
        /// <summary>
        /// End Page
        /// </summary>
        [JsonProperty(PropertyName = "end")]
        public string EndPage { get; set; }
    }

    /// <summary>
    /// The food report
    /// </summary>
    public class FoodReportFood
    {
        /// <summary>
        /// Release version of the data being reported
        /// </summary>
        [JsonProperty(PropertyName = "sr")]
        public string ReleaseVersion { get; set; }
        /// <summary>
        /// Report type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string ReportType { get; set; }
        /// <summary>
        /// Metadata elements for the food being reported
        /// </summary>
        [JsonProperty(PropertyName = "desc")]
        public FoodReportDetail FoodReportDetail { get; set; }
        /// <summary>
        /// All nutrients in the food report
        /// </summary>
        [JsonProperty(PropertyName = "nutrients")]
        public List<FoodReportNutrient> Nutrients { get; set; }
        /// <summary>
        /// Ingredients (Branded Food Products report only)
        /// </summary>
        [JsonProperty(PropertyName = "ing")]
        public Ingredients Ingredients { get; set; }

        /// <summary>
        /// Reference sources, usually a bibliographic citation, for the food
        /// </summary>
        [JsonProperty(PropertyName = "sources")]
        public List<FoodReportSource> Sources { get; set; }
        /// <summary>
        /// Unknown
        /// </summary>
        [JsonProperty(PropertyName = "footnotes")]
        public List<FoodReportFootnote> Footnotes { get; set; }
        /// <summary>
        /// LANGUAL codes assigned to the food
        /// </summary>
        [JsonProperty(PropertyName = "langual")]
        public List<FoodReportLangual> LangualCodes { get; set; }
    }

    /// <summary>
    /// LANGUAL codes assigned to the food
    /// </summary>
    public class FoodReportLangual
    {
        /// <summary>
        /// LANGUAL code
        /// </summary>
        [JsonProperty(PropertyName ="code")]
        public string Code { get; set; }

        /// <summary>
        /// description of the code
        /// </summary>
        [JsonProperty(PropertyName = "desc")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Footnote
    /// </summary>
    public class FoodReportFootnote
    {
        /// <summary>
        /// footnote id
        /// </summary>
        [JsonProperty(PropertyName = "idv")]
        public string FootnoteId { get; set; }

        /// <summary>
        /// text of the foodnote
        /// </summary>
        [JsonProperty(PropertyName = "desc")]
        public string Description { get; set; }
    }

    /// <summary>
    /// the list of foods reported for a request and errors
    /// </summary>
    public class UsdaFoodReportMetaData
    {
        /// <summary>
        /// The food
        /// </summary>
        [JsonProperty(PropertyName = "food")]
        public FoodReportFood Food { get; set; }
        /// <summary>
        /// The error if the food cannot be retrieved
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }

    /// <summary>
    /// https://ndb.nal.usda.gov/ndb/doc/apilist/API-FOOD-REPORTV2.md
    /// </summary>
    public class UsdaFoodReport
    {
        /// <summary>
        /// the list of foods reported for a request
        /// </summary>
        [JsonProperty(PropertyName = "foods")]
        public List<UsdaFoodReportMetaData> FoodList { get; set; }
        /// <summary>
        /// Number of foods requested and processed
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        /// <summary>
        /// Number of requested foods not found in the database
        /// </summary>
        [JsonProperty(PropertyName = "notfound")]
        public int NotFoundCount { get; set; }
        /// <summary>
        /// API Version
        /// </summary>
        [JsonProperty(PropertyName = "api")]
        public double ApiVersion { get; set; }
    }
}
