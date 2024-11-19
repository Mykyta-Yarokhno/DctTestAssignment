using DctTestAssignment.ViewModels;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Windows;


namespace DctTestAssignment
{
    public partial class MainWindow : Window
    {

        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }

        private void EnglishButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App)?.ChangeLanguage("en");
        }

        private void UkrainianButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App)?.ChangeLanguage("uk");
        }
    }
}