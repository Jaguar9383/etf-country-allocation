using System;

namespace MyEtf.Models.Data
{
    public class Company 
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string ISIN { get; set; }
    }
}