using PriceExtractor.Entities;
using PriceExtractor.Enums;

namespace PriceExtractor.Tools
{
    public class TextExtractor
    {
        public static List<NegotiationAsset> ExtractInText(string inputText, DateTime negotiationDate)
        {
            ValidateInput(inputText, negotiationDate);
            var lines = inputText.Split("\r\n");
            var negotiationList = new List<NegotiationAsset>();

            foreach (var line in lines)
            {
                var columns = line.Split(" ");

                negotiationList.Add(new NegotiationAsset
                {
                    StockCode = TakeAssetName(columns),
                    Amount = Convert.ToInt32(columns[^4]),
                    Price = Convert.ToDouble(columns[^3]),
                    NegotiationDate = negotiationDate,
                    AssetType = TakeAssetType(columns),
                    OperationType = (columns[1].ToUpper() == "C") ? OperationType.Buy : OperationType.Sell
                });
            }

            return negotiationList;
        }

        private static void ValidateInput(string inputText, DateTime negotiationDate)
        {
            if (string.IsNullOrEmpty(inputText))
                throw new Exception("Texto vazio.");

            if (negotiationDate == DateTime.MinValue)
                throw new Exception("Informe a data de negociação.");
        }

        private static AssetType TakeAssetType(string[] columns)
        {
            return TakeAssetType(columns[2]);
        }

        private static AssetType TakeAssetType(string negotiationDocumentType)
        {
            if (negotiationDocumentType.ToUpper() == "VISTA")
                return AssetType.FII;
            if (negotiationDocumentType.ToUpper() == "FRACIONARIO")
                return AssetType.Acao;
            throw new Exception("Tipo de Ativo não conhecido: " + negotiationDocumentType.ToUpper());
        }

        private static string TakeAssetName(string[] columns)
        {
            string assetName = string.Empty;

            if (TakeAssetType(columns) == AssetType.FII)
            {
                var columnsFII = columns.Skip(4);
                foreach (var column in columnsFII)
                {
                    if (column.Length == 6 && column.Substring(4) == "11")
                    {
                        assetName = column;
                        break;
                    }
                }
            }
            else if (TakeAssetType(columns) == AssetType.Acao)
            {
                assetName = columns[3];
            }

            return assetName;
        }
    }
}