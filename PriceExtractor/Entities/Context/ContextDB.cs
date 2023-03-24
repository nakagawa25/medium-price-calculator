using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
            string path = string.Empty;
#if DEBUG
            var databasePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            path = string.Concat("Data Source=", databasePath, "\\PriceExtractor\\DataBase\\DataBase.db");
#else
            path = string.Concat("Data Source=",Directory.GetCurrentDirectory(), "\\DataBase.db");  
#endif
            optionsBuilder.UseSqlite(path);
        }
    }
}
