using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ReadingIsGood.Core.DBEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Infrastructure.Data
{
    public class ReadingIsGoodDBContext : DbContext
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
            optionsBuilder.UseSqlServer(defaultString);
        }
    }

   
}
