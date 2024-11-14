using System.Runtime.Serialization;

namespace DctTestAssignment.Models
{
    public class CryptoCurrency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public Quote Quote { get; set; }
    }

    public class Quote
    {
        public USD USD { get; set; }
    }

    [DataContract]
    public class USD
    {
        [DataMember]
        public decimal Price { get; set; }

        [DataMember(Name = "Volume_24h")]
        public decimal Volume24h { get; set; }

        [DataMember(Name = "Percent_Change_24h")]
        public decimal PercentChange24h { get; set; }
    }
}
