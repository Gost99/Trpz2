using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Trpz2.Helpers
{
    public class SimpleCommand : ICommand
    {
        #region Fields

        private readonly Action _execute = null;
        private readonly Predicate<object> _canExecute = null;

        #endregion


        #region Constructors

        public SimpleCommand(Action execute)
            : this(execute, null)
        {
        }

        public SimpleCommand(Action execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion


        #region ICommand Implementation

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        #endregion
    }
}
