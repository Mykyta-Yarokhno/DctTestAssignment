using CryptoCurrenciesInfoApp.ViewModels;
using System.Windows.Controls;

namespace DctTestAssignment.Views
{
    public partial class CurrencyDetailsPage : UserControl
    {
        private readonly CurrencyDetailsViewModel _currencyDetailsViewModel;

        public CurrencyDetailsPage(CurrencyDetailsViewModel currencyDetailsViewModel)
        {
            InitializeComponent();
            _currencyDetailsViewModel = currencyDetailsViewModel;
            DataContext = currencyDetailsViewModel;
        }
    }
}
