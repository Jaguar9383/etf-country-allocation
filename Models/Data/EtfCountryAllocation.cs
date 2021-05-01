using System;

namespace MyEtf.Models.Data
{
    public class EtfCountryAllocation
    {
        public Guid Id {get;set;}
        public Guid EtfId {get;set;}
        public Guid CountryId {get;set;}
        public float Allocation {get;set;}

        public virtual Etf Etf {get;set;}
        public virtual Country Country {get;set;}
    }
}