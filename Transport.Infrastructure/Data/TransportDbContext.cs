using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Domain.Models;

namespace Transport.Infrastructure.Data
{
    public class TransportDbContext : DbContext
    {
        public TransportDbContext(DbContextOptions<TransportDbContext> options) : base()
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    // Create Database if cannot connect
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();

                    // Create Tables if no tables exist
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public DbSet<Product> product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Product A",
                    ProductDescription = "Product A",
                    ProductCode = "P-A",
                    ProductPrice = 100,
                    CategoryId = 1,
                },
               new Product
               {
                   ProductId = 2,
                   ProductName = "Product B",
                   ProductDescription = "Product B",
                   ProductCode = "P-B",
                   ProductPrice = 200,
                   CategoryId = 2,
               },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Product C",
                    ProductDescription = "Product C",
                    ProductCode = "P-C",
                    ProductPrice = 400,
                    CategoryId = 3,
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Product D",
                    ProductDescription = "Product D",
                    ProductCode = "P-D",
                    ProductPrice = 500,
                    CategoryId = 1,
                }
               );
        }
    }
}
