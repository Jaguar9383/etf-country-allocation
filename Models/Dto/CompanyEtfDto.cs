using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyEtf.Models.Dto
{
    public class CompanyEtfAllocationDto 
    {
        [JsonPropertyName("aaData")]
        public List<List<object>> Data { get; set; }
    }

    public class CompanyEtfDto
    {
        public string Ticker {get;set;}
        public string Name {get;set;}
        public string ISIN {get;set;}
        public string Country {get;set;}
        public string StockExchange { get; set; }
        public string Currency { get; set; }
        public float Percent {get;set;}
    }

    public class DisplayRaw
    {
        [JsonPropertyName("display")]
        public string Display {get;set;}

        [JsonPropertyName("raw")]
        public float Raw {get;set;}
    }
}
