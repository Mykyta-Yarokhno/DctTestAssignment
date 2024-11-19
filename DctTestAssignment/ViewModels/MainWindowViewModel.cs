using DctTestAssignment.Base;
using DctTestAssignment.Models;
using DctTestAssignment.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DctTestAssignment.ViewModels
{
    public  class MainWindowViewModel: ViewModelBase
    {
        public ICommand NavigateToCurrenciesPageCommand { get; }
        public ICommand NavigateConvertCommand { get; }
        public ICommand OpenCurrencyDetailsCommand { get; }

        private readonly Stack<object> _navigationStack = new Stack<object>();

        private object _currentPage;

        public object CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    RaisePropertyChanged(nameof(CurrentPage));
                }
            }
        }

        public ObservableCollection<ButtonViewModel> NavigateButtons { get; }

        public MainWindowViewModel()
        {
            NavigateButtons = new ObservableCollection<ButtonViewModel>();

            NavigateToCurrenciesPageCommand = new RelayCommand(NavigateToCurrenciesPage);
            NavigateConvertCommand = new RelayCommand(NavigateToConvertPage);
            OpenCurrencyDetailsCommand = new RelayCommand<CryptoCurrency>(NavigateToCurrencyDetailsPage);

            NavigateToCurrenciesPage();
        }

        private void NavigateToCurrenciesPage()
        {
            var currenciesPage = new CurrenciesPage(new CurrenciesViewModel(), OpenCurrencyDetailsCommand);
            _navigationStack.Push(currenciesPage);
            CurrentPage = currenciesPage;
        }

        private void NavigateToConvertPage()
        {
            var convertPage = new ConvertPage(new ConvertViewModel());
            _navigationStack.Push(convertPage);
            CurrentPage = convertPage;
        }

        private void NavigateToCurrencyDetailsPage(CryptoCurrency selectedCurrency)
        {
            var detailPage = new CurrencyDetailsPage(new CurrencyDetailsViewModel(selectedCurrency));
            _navigationStack.Push(detailPage);
            CurrentPage = detailPage;

            var buttonViewModel = new ButtonViewModel
            {
                CurrencyName = selectedCurrency.Name,
                NavigateCommand = new RelayCommand(() => CurrentPage = detailPage)
            };

            buttonViewModel.RemoveCommand = new RelayCommand(() => CloseCurrencyDetailsPage(buttonViewModel));

            NavigateButtons.Add(buttonViewModel);
        }

        private void CloseCurrencyDetailsPage(ButtonViewModel buttonViewModel)
        {
            if (_navigationStack.Count > 1)
            {
                _navigationStack.Pop();
                CurrentPage = _navigationStack.Peek(); 
                NavigateButtons.Remove(buttonViewModel);
            }
        }

        public class ButtonViewModel
        {
            public string CurrencyName { get; set; }
            public ICommand NavigateCommand { get; set; }
            public ICommand RemoveCommand { get; set; }
        }
    }
}
