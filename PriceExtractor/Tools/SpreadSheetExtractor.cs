using ClosedXML.Excel;
using PriceExtractor.Entities;
using System.Globalization;

namespace PriceExtractor.Tools
{
    public static class SpreadSheetExtractor
    {
        public static List<Dividends> ExtractDividendsFromFile(string filePath)
        {
            var dividends = new List<Dividends>();

            using (var workbook = new XLWorkbook(filePath))
            {
                // A seguir deve ser informado o nome da planilha.
                var worksheet = workbook.Worksheet("Proventos Recebidos");

                if (worksheet == null)
                    throw new Exception("Informe o nome da planilha (não o nome do arquivo) correto.");

                // Assumindo que os dados começam na linha 2 (linha 1 são os cabeçalhos)
                var initialLine = 2;

                // Itera sobre as linhas da planilha
                foreach (var row in worksheet.Rows(initialLine, worksheet.LastRowUsed().RowNumber()))
                {
                    var provento = new Dividends
                    {
                        Product = row.Cell(1).GetValue<string>(),
                        PaymentDate = row.Cell(2).GetValue<string>(),
                        PaymentType = row.Cell(3).GetValue<string>(),
                        Institution = row.Cell(4).GetValue<string>(),
                        Quantity = row.Cell(5).GetValue<string>(),
                        UnityPrice = PriceParse(row.Cell(6).GetValue<string>()),
                        NetValue = PriceParse(row.Cell(7).GetValue<string>())
                    };

                    dividends.Add(provento);
                }
            }

            return dividends;
        }

        private static decimal PriceParse(string price)
        {
            // Remove os espaços e o símbolo "R$"
            price = price.Replace("R$", "").Trim();

            // Substitui a vírgula por ponto para conversão para decimal
            price = price.Replace(",", ".");

            return decimal.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor) ? valor : 0;
        }
    }
}