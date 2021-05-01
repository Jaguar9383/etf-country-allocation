using System;
using System.Collections.Generic;

namespace MyEtf.Models.Data
{
    public class Etf
    {
        public Guid Id {get;set;}
        public string Name {get;set;}
        public string Code {get;set;}

        public virtual ICollection<EtfCountryAllocation> Allocations {get;set;}
    }
}