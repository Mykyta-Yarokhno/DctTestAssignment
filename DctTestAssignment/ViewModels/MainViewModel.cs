using DctTestAssignment.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DctTestAssignment.ViewModels
{
    public  class MainViewModel: INotifyPropertyChanged
    {
        private readonly CoinMarketCapApiService _cryptoService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<CryptoCurrency> TopCurrencies { get; set; }

        public MainViewModel()
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
