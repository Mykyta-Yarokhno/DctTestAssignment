using DctTestAssignment.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace DctTestAssignment.ViewModels
{
    class CurrencyDetailsViewModel: INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal PriceChange { get; set; }
        public ObservableCollection<MarketInfo> Markets { get; set; }

        public ICommand OpenMarketLinkCommand { get; }

        public CurrencyDetailsViewModel(CryptoCurrency selectedCurrency)
        {
            Name = selectedCurrency.Name;
            Symbol = selectedCurrency.Symbol;
            Price = selectedCurrency.Quote.USD.Price;
            Volume = selectedCurrency.Quote.USD.Volume24h;
            PriceChange = selectedCurrency.Quote.USD.PercentChange24h;

            Markets = new ObservableCollection<MarketInfo>
            {
                new MarketInfo { MarketName = "Binance", MarketPrice = Price, MarketVolume = Volume / 2, MarketLink = "https://www.binance.com" },
                new MarketInfo { MarketName = "Coinbase", MarketPrice = Price + 50, MarketVolume = Volume / 3, MarketLink = "https://www.coinbase.com" }
            };

            OpenMarketLinkCommand = new RelayCommand(OpenMarketLink);
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
