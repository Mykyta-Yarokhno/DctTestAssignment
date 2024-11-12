using DctTestAssignment.Models;
using DctTestAssignment.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace DctTestAssignment.ViewModels
{
    public class CurrencyDetailsViewModel: INotifyPropertyChanged
    {
        private readonly CoinCapApiService _cryptoService;

        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }
        public ObservableCollection<CurrencyMarketInfo> CurrencyMarkets { get; set; }

        public CryptoCurrency SelectedCurrency { get; }

        public ICommand OpenMarketLinkCommand { get; }

        public CurrencyDetailsViewModel(CryptoCurrency selectedCurrency)
        {
            SelectedCurrency = selectedCurrency;

            _cryptoService = new CoinCapApiService();
            CurrencyMarkets = new ObservableCollection<CurrencyMarketInfo>();

            Name = selectedCurrency.Name;
            Symbol = selectedCurrency.Symbol;
            Price = selectedCurrency.Quote.USD.Price;
            Volume = selectedCurrency.Quote.USD.Volume24h;
            PriceChange = selectedCurrency.Quote.USD.PercentChange24h;

            GetCurrencyMarkets(selectedCurrency.Symbol);

            OpenMarketLinkCommand = new RelayCommand(OpenMarketLink);            
        }

        private async void GetCurrencyMarkets(string currencySymbol, string currencyQuote = "USD")
        {
            var markets = await _cryptoService.GetCurrencyMarkets(currencySymbol, currencyQuote);

            foreach (var market in markets)
            {
                if(market.CurrencyQuoteSymbol == currencyQuote)
                    CurrencyMarkets.Add(market);
            }
        }

        private void OpenMarketLink(object link)
        {
            if (link is string url)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
