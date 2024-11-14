using DctTestAssignment.Models;
using DctTestAssignment.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DctTestAssignment.Views
{
    public partial class CurrenciesPage : UserControl
    {
        private readonly CurrenciesViewModel _currenciesViewModel;
        private readonly ICommand _openCurrencyDetailsCommand;

        public CurrenciesPage(CurrenciesViewModel currenciesViewModel, ICommand openCurrencyDetailsCommand)
        {
            InitializeComponent();
            _currenciesViewModel = currenciesViewModel;
            DataContext = currenciesViewModel;

            _openCurrencyDetailsCommand = openCurrencyDetailsCommand;
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrencyListView.SelectedItem is CryptoCurrency selectedCurrency)
                _openCurrencyDetailsCommand?.Execute(selectedCurrency);

        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var selectedCurrency = button?.DataContext as CryptoCurrency;

            if (selectedCurrency != null)
                _openCurrencyDetailsCommand?.Execute(selectedCurrency);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();

            foreach (var item in CurrencyListView.Items)
            {
                if (item is CryptoCurrency currency)
                {
                    if (currency.Name.Equals(searchText, StringComparison.CurrentCultureIgnoreCase) || currency.Symbol.Equals(searchText, StringComparison.CurrentCultureIgnoreCase))
                        CurrencyListView.SelectedItem = item;
                }
            }
        }

    }
}
