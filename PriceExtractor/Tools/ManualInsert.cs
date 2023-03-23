using PriceExtractor.Entities;
using PriceExtractor.Enums;

namespace PriceExtractor.Tools
{
    public static class ManualInsert
    {
        public static NegotiationAsset GetNegotiationObject(string code, AssetType type, int amount, DateTime date, double totalValue)
        {
            var negotiation = new NegotiationAsset()
            {
                StockCode = code,
                AssetType = type,
                Amount = amount,
                NegotiationDate = date,
                Price = totalValue / amount
            };

            return negotiation;
        }

        public static void Insert(NegotiationAsset negotiation)
        {
            Services.NegotiationAssetService.InsertNegotiationAsset(negotiation);
        }
    }
}
