using System;
using System.Windows.Input;

namespace RSS_Module
{
    /// <summary>
    /// Implementation of ICommand 
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Fields
        Action<object> _execteMethod;
        Func<object, bool> _canexecuteMethod;
        #endregion

        #region Ctor
        public RelayCommand(Action<object> execteMethod, Func<object, bool> canexecuteMethod)
        {
            _execteMethod = execteMethod;
            _canexecuteMethod = canexecuteMethod;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Infrastructure for CanExecute
        /// </summary>
        /// <param name="parameter">parameter for an Func</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canexecuteMethod != null)
            {
                return _canexecuteMethod(parameter);
            }
            else
            {
                return false;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Infrastructure for Execute Action
        /// </summary>
        /// <param name="parameter">parameter for an Action</param>
        public void Execute(object parameter)
        {
            _execteMethod(parameter);
        } 
        #endregion
    }
}