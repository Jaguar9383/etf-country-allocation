using Microsoft.EntityFrameworkCore;
using MyEtf.Models.Data;

namespace MyEtf.Context {
    public class MyEtfContext : DbContext {
        public DbSet<Country> Countries {get;set;}
        public DbSet<Etf> Etfs {get;set;}
        public DbSet<EtfCountryAllocation> EtfCountryAllocations {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=app.db");
    }
}