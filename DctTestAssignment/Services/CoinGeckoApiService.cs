using DctTestAssignment.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace DctTestAssignment.Services
{
    class CoinGeckoApiService
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "DctTestAssignment");
        }
        public async Task<List<CryptoCurrency>> GetTopCurrenciesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&per_page=10&page=1");
            var result = JsonConvert.DeserializeObject<List<CryptoCurrency>>(response);
            return result;
        }

        public async Task<List<CurrencyHistoricalPriceData>> GetOHLCDataAsync(string coinId, string vsCurrency, int days)
        {
            var response = await _httpClient.GetStringAsync($"https://api.coingecko.com/api/v3/coins/{coinId}/ohlc?vs_currency={vsCurrency}&days={days}");
            var candles = JsonConvert.DeserializeObject<List<List<object>>>(response);

            var candleList = candles.Select(item => new CurrencyHistoricalPriceData
            {
                Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(item[0])).DateTime,
                Open = Convert.ToDecimal(item[1]),
                High = Convert.ToDecimal(item[2]),
                Low = Convert.ToDecimal(item[3]),
                Close = Convert.ToDecimal(item[4])
            }).ToList();

            return candleList;
        }
    }
}
