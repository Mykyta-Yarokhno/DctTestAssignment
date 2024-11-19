using System.Windows;
using System.Windows.Controls;
using CryptoCurrenciesInfoApp.ViewModels;

namespace DctTestAssignment.Views
{
    public partial class ConvertPage : UserControl
    {
        public ConvertPage(ConvertViewModel convertViewModel)
        {
            InitializeComponent();
            DataContext = convertViewModel;
        }

        private async void OnConvertButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ConvertViewModel convertViewModel)
            {
                await convertViewModel.ConvertCurrencyAsync();
            }
        }
    }
}
