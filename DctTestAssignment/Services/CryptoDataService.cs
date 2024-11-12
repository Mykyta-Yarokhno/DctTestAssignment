using DctTestAssignment.Models;

namespace DctTestAssignment.Services
{
    public class CryptoDataService
    {
        private readonly CoinCapApiService _coinCapApiService;
        private readonly CoinMarketCapApiService _coinMarketCapApiService;

        public CryptoDataService(CoinCapApiService coinCapApiService, CoinMarketCapApiService coinMarketCapApiService)
        {
            _coinCapApiService = coinCapApiService;
            _coinMarketCapApiService = coinMarketCapApiService;
        }

        public async Task<List<CryptoCurrency>> GetTopCurrenciesAsync()
        {
            return await _coinMarketCapApiService.GetTopCurrenciesAsync();
        }

        //public async Task<List<CurrencyMarketInfo>?> GetCurrencyMarketsAsync(string currencyId)
        //{
        //    return await _coinCapApiService.GetCurrencyMarkets(currencyId);
        //}
    }
}
