using DctTestAssignment.ViewModels;
using DctTestAssignment.Views;
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
    }
}