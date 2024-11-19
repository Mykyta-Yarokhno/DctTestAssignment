using System.Windows.Input;

namespace CryptoCurrenciesInfoApp
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Action<object?> _executeWithParameter;
        private readonly Func<bool>? _canExecute;
        private readonly Func<object?, bool>? _canExecuteWithParameter;

        public RelayCommand(Action execute)
            : this(execute != null ? new Action<object?>(_ => execute()) : throw new ArgumentNullException(nameof(execute)))
        {
        }

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _executeWithParameter = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteWithParameter = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object? parameter) => _executeWithParameter(parameter);

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || parameter is T t && _canExecute(t);

        public void Execute(object? parameter)
        {
            if (parameter is T t)
            {
                _execute(t);
            }
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
