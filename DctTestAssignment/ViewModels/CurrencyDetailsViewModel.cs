using DctTestAssignment.Base;
using DctTestAssignment.Models;
using DctTestAssignment.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace DctTestAssignment.ViewModels
{
    public class CurrencyDetailsViewModel: ViewModelBase
    {
        private readonly CryptoDataService _cryptoDataService;

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

            _cryptoDataService = new CryptoDataService();
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
            var markets = await _cryptoDataService.GetCurrencyMarketsAsync(currencySymbol, currencyQuote);

            foreach (var market in markets)
            {
                if(market.CurrencyQuoteSymbol == currencyQuote)
                    CurrencyMarkets.Add(market);
            }
        }

        private void OpenMarketLink(object? link)
        {
            if (link is string url && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true 
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open link: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("The provided URL is not valid.");
            }
        }
    }
}
