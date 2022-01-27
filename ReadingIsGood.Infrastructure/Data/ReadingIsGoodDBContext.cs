using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Infrastructure.Data
{
    public class ReadingIsGoodDBContext : IdentityDbContext<ApplicationUser>
    {
    public ReadingIsGoodDBContext(DbContextOptions<ReadingIsGoodDBContext> options)
    : base(options)
    {
        
    }

  
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            string defaultString = jAppSettings["ConnectionString"]["DefaultConnection"].Value<string>();
            //optionsBuilder.UseSqlServer(defaultString);
            optionsBuilder.UseSqlite(defaultString);
        }
    }

   
}
