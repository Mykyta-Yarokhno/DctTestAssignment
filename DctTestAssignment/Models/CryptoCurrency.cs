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

    public class USD
    {
        public decimal Price { get; set; }
        public decimal Volume24h { get; set; }
        public decimal PercentChange24h { get; set; }
    }
}
