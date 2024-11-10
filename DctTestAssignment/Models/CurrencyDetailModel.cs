namespace DctTestAssignment.Models
{
    public class CurrencyDetailModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }
        public List<MarketInfo> Markets { get; set; }
    }

    public class MarketInfo
    {
        public string MarketName { get; set; }
        public decimal MarketPrice { get; set; }
        public decimal MarketVolume { get; set; }
        public string MarketLink { get; set; }
    }
}
