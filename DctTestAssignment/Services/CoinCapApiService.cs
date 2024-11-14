using DctTestAssignment.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace DctTestAssignment.Services
{
    public class CoinCapApiService
    {
        private readonly HttpClient _httpClient;

        public CoinCapApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CurrencyMarketInfo>?> GetCurrencyMarkets(string currencySymbol, string currencyQuote)
        {
            var response = await _httpClient.GetStringAsync($"https://api.coincap.io/v2/markets?baseSymbol={currencySymbol}&quoteSymbol={currencyQuote}");
            var responseExchanges = await _httpClient.GetStringAsync($"https://api.coincap.io/v2/exchanges");

            var result = JsonConvert.DeserializeObject<CoinCapApiResponse>(response)?.Data;
            var resultExchanges = JsonConvert.DeserializeObject<CoinCapApiResponseExchange>(responseExchanges)?.Data;

            var query = from currencyMarket in result
                        join exchange in resultExchanges on currencyMarket.MarketId equals exchange.MarketId
                        select (currencyMarket, exchange);

            foreach (var (currencyMarket, exchange) in query)
            {
                currencyMarket.MarketLink = exchange.MarketLink;
                currencyMarket.MarketName = exchange.MarketName;
            }

            return result.Where(currencyMarket => currencyMarket.MarketName != null).ToList();
        }
    }

    public class CoinCapApiResponse
    {
        public List<CurrencyMarketInfo> Data { get; set; }
    }

    public class CoinCapApiResponseExchange
    {
        public List<ExchangeInfo> Data { get; set; }
    }
}

