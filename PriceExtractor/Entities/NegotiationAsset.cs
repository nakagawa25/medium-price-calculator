using PriceExtractor.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PriceExtractor.Entities
{
    public class NegotiationAsset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StockCode { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public DateTime NegotiationDate { get; set; }
        public AssetType AssetType { get; set; }
        public OperationType OperationType { get; set; }
    }
}
