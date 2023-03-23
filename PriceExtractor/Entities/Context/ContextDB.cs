using Microsoft.EntityFrameworkCore;

namespace PriceExtractor.Entities.Context
{
    public class ContextDB : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<NegotiationAsset> Negotiations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = string.Concat("Data Source=",Directory.GetCurrentDirectory(), "\\DataBase.db");
            optionsBuilder.UseSqlite(path);    
        }
    }
}
