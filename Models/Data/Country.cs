using System;
using System.Collections.Generic;

namespace MyEtf.Models.Data
{
    public class Country
    {
        public Guid Id {get;set;}
        public string Name {get;set;}

        public virtual ICollection<Etf> Etfs {get;set;}
    }
}