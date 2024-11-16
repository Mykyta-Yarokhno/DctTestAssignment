using DctTestAssignment.Models;

namespace DctTestAssignment.Services
{
    public class CryptoDataService
    {
        private readonly CoinCapApiService _coinCapApiService;
        private readonly CoinMarketCapApiService _coinMarketCapApiService;
        private readonly CoinGeckoApiService _coinGeckoApiService;

        public CryptoDataService()
        {
            _coinCapApiService = new CoinCapApiService();
            _coinMarketCapApiService = new CoinMarketCapApiService();
            _coinGeckoApiService = new CoinGeckoApiService();
        }

        public async Task<List<CryptoCurrency>> GetTopCurrenciesAsync()
        {
            return await _coinMarketCapApiService.GetTopCurrenciesAsync();
        }

        public async Task<List<CurrencyMarketInfo>?> GetCurrencyMarketsAsync(string currencyId, string currencyQuote)
        {
            return await _coinCapApiService.GetCurrencyMarketsAsync(currencyId, currencyQuote);
        }

        public async Task<List<CurrencyHistoricalPriceData>> GetOHLCDataAsync(string coinId, string vsCurrency, int days)
        {
            return await _coinGeckoApiService.GetOHLCDataAsync(coinId, vsCurrency, days);
        }
    }
}
