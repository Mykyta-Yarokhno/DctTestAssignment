using DctTestAssignment.Models;

namespace DctTestAssignment.Services
{
    public class CryptoDataService
    {
        private readonly CoinCapApiService _coinCapApiService;
        private readonly CoinGeckoApiService _coinGeckoApiService;
        private readonly CoinMarketCapApiService _coinMarketCapApiService;

        public CryptoDataService()
        {
            _coinCapApiService = new CoinCapApiService();
            _coinGeckoApiService = new CoinGeckoApiService();
            _coinMarketCapApiService = new CoinMarketCapApiService();
        }

        public async Task<List<CryptoCurrency>> GetTopCurrenciesAsync()
        {
            return await _coinGeckoApiService.GetTopCurrenciesAsync();
        }

        public async Task<List<CurrencyMarketInfo>?> GetCurrencyMarketsAsync(string currencyId, string currencyQuote)
        {
            return await _coinCapApiService.GetCurrencyMarketsAsync(currencyId, currencyQuote);
        }

        public async Task<List<CurrencyHistoricalPriceData>> GetOHLCDataAsync(string coinId, string vsCurrency, int days)
        {
            return await _coinGeckoApiService.GetOHLCDataAsync(coinId, vsCurrency, days);
        }

        public async Task<decimal> ConvertCurrencyAsync(decimal amount, string fromSymbol, string toSymbol)
        {
            return await _coinMarketCapApiService.ConvertCurrencyAsync(amount, fromSymbol, toSymbol);
        }
    }
}
