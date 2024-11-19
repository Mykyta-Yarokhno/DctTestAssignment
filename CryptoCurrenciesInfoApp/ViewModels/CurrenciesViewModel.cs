using CryptoCurrenciesInfoApp.Base;
using CryptoCurrenciesInfoApp.Models;
using CryptoCurrenciesInfoApp.Services;
using System.Collections.ObjectModel;

namespace CryptoCurrenciesInfoApp.ViewModels
{
    public class CurrenciesViewModel : ViewModelBase
    {
        private readonly CryptoDataService _cryptoDataService;

        public ObservableCollection<CryptoCurrency> TopCurrencies { get; set; }

        public CurrenciesViewModel()
        {
            _cryptoDataService = new CryptoDataService();
            TopCurrencies = new ObservableCollection<CryptoCurrency>();
            LoadTopCurrencies();
        }

        private async void LoadTopCurrencies()
        {
            var currencies = await _cryptoDataService.GetTopCurrenciesAsync();
            TopCurrencies.Clear();
            foreach (var currency in currencies)
            {
                TopCurrencies.Add(currency);
            }
        }

    }
}
