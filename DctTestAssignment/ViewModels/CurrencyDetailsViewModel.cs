using DctTestAssignment.Base;
using DctTestAssignment.Models;
using DctTestAssignment.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace DctTestAssignment.ViewModels
{
    public class CurrencyDetailsViewModel: ViewModelBase
    {
        private readonly CryptoDataService _cryptoDataService;
        public PlotModel CandleStickPlotModel { get; private set; }

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
            CandleStickPlotModel = new PlotModel { Title = "Price Chart" };
            LoadCandleStickChart();

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

        private async void LoadCandleStickChart(string coinId = "binancecoin", string vsCurrency = "usd", int days = 7)
        {
            var rawCandles = await _cryptoDataService.GetOHLCDataAsync(coinId, vsCurrency, days);

            var candles = rawCandles.Select(c => new
            {
                c.Timestamp,
                c.Open,
                c.High,
                c.Low,
                c.Close
            }).ToList();

            CandleStickPlotModel = new PlotModel { Title = $"{coinId.ToUpper()}/{vsCurrency.ToUpper()} Candlestick Chart" };

            CandleStickPlotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "HH:mm",
                Title = "Time",
                IntervalType = DateTimeIntervalType.Hours,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });

            CandleStickPlotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Price",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });

            var series = new CandleStickSeries
            {
                ItemsSource = candles,
                DataFieldX = "Timestamp", 
                DataFieldHigh = "High",   
                DataFieldLow = "Low",      
                DataFieldOpen = "Open",    
                DataFieldClose = "Close",  
                Title = "Candles"
            };

            CandleStickPlotModel.Series.Add(series);

            RaisePropertyChanged(nameof(CandleStickPlotModel));
        }
    }
}
