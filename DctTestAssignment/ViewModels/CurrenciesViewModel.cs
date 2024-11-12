using DctTestAssignment.Base;
using DctTestAssignment.Models;
using DctTestAssignment.Services;
using System.Collections.ObjectModel;

namespace DctTestAssignment.ViewModels
{
    public  class CurrenciesViewModel: ViewModelBase
    {
        private readonly CoinMarketCapApiService _cryptoService;

        public ObservableCollection<CryptoCurrency> TopCurrencies { get; set; }

        public CurrenciesViewModel()
        {
            _cryptoService = new CoinMarketCapApiService();
            TopCurrencies = new ObservableCollection<CryptoCurrency>();
            LoadTopCurrencies();
        }

        private async void LoadTopCurrencies()
        {
            var currencies = await _cryptoService.GetTopCurrenciesAsync();
            TopCurrencies.Clear();
            foreach (var currency in currencies)
            {
                TopCurrencies.Add(currency);
            }
        }

    }
}
