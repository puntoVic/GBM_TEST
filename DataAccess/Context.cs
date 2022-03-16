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
        
        public DbSet<Issuer> Issuers { get; set; }
        public DbSet<Issuer> Stocks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                if (GeneralConfig.Connstring == null)
                {
                    // Only used when generating migrations
                    options.UseSqlServer("Server=DESKTOP-E0Q3KH2; Database= APITestGBM; User Id= sa; Password = SQL123;");
                }
                else
                {
                    options.UseSqlServer(GeneralConfig.Connstring);
                }
            
                    
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}

