namespace PriceExtractor.Entities
{
    public class Dividends
    {
        public string Product { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public string Institution { get; set; }
        public string Quantity { get; set; }
        public decimal UnityPrice { get; set; }
        public decimal NetValue { get; set; }
    }
}
