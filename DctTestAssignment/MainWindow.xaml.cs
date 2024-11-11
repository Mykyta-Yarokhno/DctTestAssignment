using DctTestAssignment.Models;
using DctTestAssignment.ViewModels;
using DctTestAssignment.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DctTestAssignment
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }

        private void NavigateCurrencies(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        public void NavigateToCurrencyDetails(CryptoCurrency selectedCurrency)
        {
            var detailPage = new CurrencyDetailPage
            {
                DataContext = new CurrencyDetailsViewModel(selectedCurrency)
            };

            var buttonContainer = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };


            var button = new Button
            {
                Content = new Grid
                {
                    Width = 100, 
                    Children =
                    {

                        new TextBlock
                        {
                            Text = selectedCurrency.Name,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center
                        },

                        new Button
                        {
                            Content = "X",
                            Width = 20,
                            BorderBrush = Brushes.Transparent,
                            BorderThickness = new Thickness(0),
                            Background = Brushes.LightSteelBlue,
                            Foreground = Brushes.Red,
                            VerticalAlignment = VerticalAlignment.Top,
                            HorizontalAlignment = HorizontalAlignment.Right,
                            FontSize = 12,
                            Padding = new Thickness(0)
                        }
                    }
                }
            };

            button.Click += (s, args) =>
            {
                MainFrame.Navigate(detailPage);
            };

            ((Button)((Grid)button.Content).Children[1]).Click += (s, args) =>
            {
                NavigateButtons.Children.Remove(buttonContainer);
            };

            buttonContainer.Children.Add(button);

            NavigateButtons.Children.Add(buttonContainer);

            MainFrame.Navigate(detailPage);
        }
        private void NavigateConvert(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }
    }
}