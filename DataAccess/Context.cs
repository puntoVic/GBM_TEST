using Microsoft.EntityFrameworkCore;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class Context : DbContext
    {
        private readonly IConfiguration configuration;
        public Context(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Context()
        {
            this.configuration = null;
        }
        public DbSet<Issuer> Issuers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                if (configuration == null)
                {
                    // Only used when generating migrations
                    options.UseSqlServer("Server=DESKTOP-E0Q3KH2; Database= APITestGBM; User Id= sa; Password = SQL123");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("DatabaseTest"));
                }
            
                    
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Issuer>().HasData(
                new Issuer { Issuer_Name = "AAPL", Value = 150 },
                new Issuer { Issuer_Name = "MSFT", Value = 276 },
                new Issuer { Issuer_Name = "GOOG", Value = 2532 },
                new Issuer { Issuer_Name = "AMZN", Value = 2845 },
                new Issuer { Issuer_Name = "TSLA", Value = 767 },
                new Issuer { Issuer_Name = "NVDA", Value = 213 },
                new Issuer { Issuer_Name = "TSM", Value = 99 },
                new Issuer { Issuer_Name = "FB", Value = 186 },
                new Issuer { Issuer_Name = "UNH", Value = 486 },
                new Issuer { Issuer_Name = "JNJ", Value = 171 }

                );




        }
    }
}

