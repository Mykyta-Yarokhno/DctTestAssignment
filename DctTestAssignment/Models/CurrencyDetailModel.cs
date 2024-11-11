using System.Runtime.Serialization;

namespace DctTestAssignment.Models
{
    public class CurrencyDetailModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }
        public List<CurrencyMarketInfo> Markets { get; set; }
    }

    [DataContract]
    public class CurrencyMarketInfo
    {
        [DataMember(Name = "baseId")]
        public string CurrencyBaseId { get; set; }

        [DataMember(Name = "baseSymbol")]
        public string CurrencyBaseSymbol { get; set; }

        [DataMember(Name = "quoteSymbol")]
        public string CurrencyQuoteSymbol { get; set; }

        [DataMember(Name = "quoteId")]
        public string CurrencyQuoteId { get; set; }

        [DataMember(Name = "exchangeId")]
        public string MarketName { get; set; }

        [DataMember(Name = "priceUsd")]
        public decimal MarketPrice { get; set; }

        [DataMember(Name = "volumePercent")]
        public decimal MarketVolume { get; set; }

        [IgnoreDataMember]
        public string MarketLink { get; set; }
    }
}
