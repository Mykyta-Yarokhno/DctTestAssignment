using DctTestAssignment.Models;
using DctTestAssignment.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

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
            {
                _openCurrencyDetailsCommand?.Execute(selectedCurrency);
            }
        }
    }
}
