using EcoApiEscen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EcoApiEscen.Database {
    public class EcoDbContext : DbContext {
        private readonly IConfiguration _configuration;

        public DbSet<Item> Items { get; set; }

        public EcoDbContext(IConfiguration configuration) { _configuration = configuration; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseMySQL(_configuration.GetConnectionString("mysql")); }
    }
}