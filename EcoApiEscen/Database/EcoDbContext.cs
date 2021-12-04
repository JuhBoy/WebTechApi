using CommandLib;
using EcoApiEscen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EcoApiEscen.Database {
    public class EcoDbContext : DbContext {
        private readonly IConfiguration _configuration;

        public DbSet<Item> Items { get; set; } // Example of table
        public DbSet<Product> Products { get; set; } // Add a new Db Set that uses Product class ass schema for the Database
        public DbSet<Price> Prices { get; set; }

        public EcoDbContext(IConfiguration configuration) { _configuration = configuration; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(_configuration["ConnectionsStrings:mysql"]);
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Product>().HasKey(product => product.Id).HasName("_id_"); // Yay ! now the product.Id is the Uniq Key "_id_" in product table.
            builder.Entity<Product>().Property(product => product.Name).IsRequired(); // Name is now required, and can't be null for table product.

            builder.Entity<Price>(op => {
                op.HasKey(pr => pr.Id).HasName("_id_"); // Adding a the primary key
                op.Property(pr => pr.Currency).IsRequired(); // Making currency not null
                op.HasOne<Product>().WithMany().HasForeignKey(pr => pr.ProductForeignKey); // 1:n relation
            });
            // ... Configure your model creation from there. :) 
        }
    }
}