using DctTestAssignment.Models;

namespace DctTestAssignment.Services
{
    public class CryptoDataService
    {
        private readonly CoinCapApiService _coinCapApiService;
        private readonly CoinMarketCapApiService _coinMarketCapApiService;

        public CryptoDataService()
        {
            _coinCapApiService = new CoinCapApiService();
            _coinMarketCapApiService = new CoinMarketCapApiService();
        }

        public async Task<List<CryptoCurrency>> GetTopCurrenciesAsync()
        {
            return await _coinMarketCapApiService.GetTopCurrenciesAsync();
        }

        public async Task<List<CurrencyMarketInfo>?> GetCurrencyMarketsAsync(string currencyId, string currencyQuote)
        {
            return await _coinCapApiService.GetCurrencyMarkets(currencyId, currencyQuote);
        }
    }
}
