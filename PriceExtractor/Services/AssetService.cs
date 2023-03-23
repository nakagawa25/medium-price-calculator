using PriceExtractor.Entities;
using PriceExtractor.Entities.Context;
using System.Collections;

namespace PriceExtractor.Services
{
    public static class AssetService
    {
        public static List<Asset> GetAllAssets()
        {
            using (var context = new ContextDB())
            {
                return context.Assets.ToList();
            }
        }

        public static List<Asset> GetAssetsByStockCode(string stockCode)
        {
            using (var context = new ContextDB())
            {
                return context.Assets.Where(a => a.StockCode == stockCode).ToList();
            }
        }

        public static void InsertAsset(Asset asset)
        {
            using (var context = new ContextDB())
            {
                context.Assets.Add(asset);
                context.SaveChanges();
            }
        }

        public static void InsertManyAssets(IEnumerable<Asset> assets)
        {
            using (var context = new ContextDB())
            {
                foreach (var asset in assets)
                    context.Assets.Add(asset);
                context.SaveChanges();
            }
        }

        public static void DeleteAll()
        {
            using (var context = new ContextDB())
            {
                context.Assets.RemoveRange(context.Assets);
                context.SaveChanges();
            }
        }
    }
}
