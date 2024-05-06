using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LR4_5;

class RelayCommand : ICommand
{
    private Action<object?> _execute;
    private Predicate<object?> _canExecute;

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    public bool CanExecute(Object? parameter)
    {
        return _canExecute(parameter) || _canExecute == null;
    }

    public RelayCommand(Action<object?> execute, Predicate<object?> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
}
