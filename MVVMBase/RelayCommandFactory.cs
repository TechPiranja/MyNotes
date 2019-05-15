using System;
using System.Windows.Input;

namespace MVVMBase
{
    /// <summary>
    /// Factory for creating new RelayCommands.
    /// </summary>
    public class RelayCommandFactory
    {
        /// <summary>
        /// Creates new instance of RelayCommand.
        /// </summary>
        /// <param name="execute">The Action that should be executed.</param>
        /// <param name="canExecute">The Predicate that indicates, whether the execute action can be executed or not.</param>
        public RelayCommand Create(Action<object> execute, Predicate<object> canExecute = null)
        {
            return new RelayCommand(execute, canExecute);
        }

        public ICommand Create(object v)
        {
            throw new NotImplementedException();
        }
    }
}