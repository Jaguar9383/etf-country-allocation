using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEtf.Models.Data
{
    public class Country
    {
        [Key]
        public Guid Id {get;set;}
        public string Name {get;set;}

        public virtual ICollection<Etf> Etfs {get;set;}
    }
}