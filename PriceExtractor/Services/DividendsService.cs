using PriceExtractor.Entities;
using PriceExtractor.Tools;
using PriceExtractor.ValueObjects;

namespace PriceExtractor.Services
{
    public static class DividendsService
    {
        const string _JCP = "Juros Sobre Capital Próprio";
        const string _Dividend = "Dividendo";
        const string _Provents = "Rendimento";

        public static List<DividendOut> GetGroupedDividends(string xlsxPath)
        {
            var dividends = SpreadSheetExtractor.ExtractDividendsFromFile(xlsxPath);

            var dividendsOut = new List<DividendOut>();

            foreach (var stockName in dividends.Select(x => x.Product).Distinct())
            {
                var assetDividends = dividends
                    .Where(x =>
                        x.Product == stockName)
                    .ToList();

                if (assetDividends.Any() && assetDividends.First().PaymentType == _Provents)
                {
                    // É um FII
                    AddDividendToList(assetDividends, _Provents, dividendsOut);
                }
                else if (assetDividends.Any())
                {
                    var stockDividends = assetDividends
                        .Where(x =>
                            x.PaymentType.ToUpper() == _Dividend.ToUpper())
                        .ToList();

                    AddDividendToList(stockDividends, _Dividend, dividendsOut);

                    var stockJcp = assetDividends
                        .Where(x =>
                            x.PaymentType.ToUpper() == _JCP.ToUpper())
                        .ToList();

                    AddDividendToList(stockJcp, _JCP, dividendsOut);
                }
            }

            dividendsOut = dividendsOut.OrderBy(x => x.PaymentType).ToList();

            return dividendsOut;
        }

        private static void AddDividendToList(List<Dividends> dividendsList, string PaymentType, List<DividendOut> dividendsOutList)
        {
            if (dividendsList.Any())
            {
                var dividendOut = new DividendOut();

                dividendOut.AssetName = dividendsList.First().Product;
                dividendOut.TotalValue = dividendsList.Sum(x => x.NetValue);
                dividendOut.PaymentType = PaymentType;

                dividendsOutList.Add(dividendOut);
            }
        }
    }
}
