using DctTestAssignment.Models;
using DctTestAssignment.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;


namespace DctTestAssignment.Views
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrencyListView.SelectedItem is CryptoCurrency selectedCurrency)
            {
                ((MainWindow)Application.Current.MainWindow)?.NavigateToCurrencyDetails(selectedCurrency);
            }
        }
    }
}
