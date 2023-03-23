using PriceExtractor.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceExtractor.Entities
{
    public class Asset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StockCode { get; set; }
        public int Amount { get; set; }
        [NotMapped]
        public double MediumPrice { get; set; }
        public double TotalValue { get; set; }
        public AssetType AssetType { get; set; }
    }
}
