using CryptoCurrenciesInfoApp.Base;
using CryptoCurrenciesInfoApp.Services;

namespace CryptoCurrenciesInfoApp.ViewModels
{
    public class ConvertViewModel : ViewModelBase
    {
        private readonly CryptoDataService _cryptoDataService;
        private decimal _amount;
        private string _fromCurrency;
        private string _toCurrency;
        private decimal _conversionResult;

        public ConvertViewModel()
        {
            _cryptoDataService = new CryptoDataService();
        }

        public decimal Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    RaisePropertyChanged(nameof(Amount));
                }
            }
        }

        public string FromCurrency
        {
            get => _fromCurrency;
            set
            {
                var upperValue = value?.ToUpper();
                if (_fromCurrency != value)
                {
                    _fromCurrency = upperValue;
                    RaisePropertyChanged(nameof(FromCurrency));
                }
            }
        }

        public string ToCurrency
        {
            get => _toCurrency;
            set
            {
                var upperValue = value?.ToUpper();
                if (_toCurrency != value)
                {
                    _toCurrency = upperValue;
                    RaisePropertyChanged(nameof(ToCurrency));
                }
            }
        }

        public decimal ConversionResult
        {
            get => _conversionResult;
            set
            {
                if (_conversionResult != value)
                {
                    _conversionResult = value;
                    RaisePropertyChanged(nameof(ConversionResult));
                }
            }
        }

        public async Task ConvertCurrencyAsync()
        {
            var result = await _cryptoDataService.ConvertCurrencyAsync(Amount, FromCurrency, ToCurrency);
            ConversionResult = result;
        }
    }
}
