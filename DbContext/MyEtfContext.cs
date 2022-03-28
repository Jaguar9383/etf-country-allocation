using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyEtf.Models.Data;

namespace MyEtf.Context {
    public class MyEtfContext : DbContext {
        // public MyEtfContext(IConfiguration configuration) {
        //     _configuration = configuration;
        // }
        // public MyEtfContext(DbContextOptions<MyEtfContext> options) : base(options)
        // {
        // }
        public DbSet<Country> Countries {get;set;}
        public DbSet<Etf> Etfs {get;set;}
        public DbSet<EtfCountryAllocation> EtfCountryAllocations {get;set;}
        public DbSet<Company> Companies {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=tcp:myemitent.ru,1433;Initial Catalog=u0420907_etf;Persist Security Info=True;User ID=u0420907_etf_sa;Password=*cIZ48Q77uqOvUK;integrated security=false;persist security info=True;MultipleActiveResultSets=True");
    }
}