using System.Runtime.Serialization;

namespace DctTestAssignment.Models
{
    [DataContract]
    public class CryptoCurrency
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember(Name = "current_price")]
        public decimal Price { get; set; }
        [DataMember(Name = "total_volume")]
        public decimal Volume { get; set; }
        [DataMember(Name = "price_change_24h")]
        public decimal PercentChange24h { get; set; }
    }
}
