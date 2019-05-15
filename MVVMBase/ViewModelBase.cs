using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMBase
{
    /// <summary>
    /// Base class for every ViewModel.
    /// It implements the everything needed.
    /// </summary>
    /// <typeparam name="TInterfaceModel">The type of the interface model.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class ViewModelBase<TInterfaceModel, TModel> : INotifyPropertyChanged
        where TModel : class, TInterfaceModel
        where TInterfaceModel : class
    {
        protected ViewModelBase()
        {
            Model = Activator.CreateInstance<TModel>();
            Factory = Activator.CreateInstance<RelayCommandFactory>();
        }

        protected TInterfaceModel Model { get; }
        protected RelayCommandFactory Factory { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Checks if a property already matches a desired value. Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Checks if a property already matches a desired value. Sets the property and
        /// notifies listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners. This
        /// value is optional and can be provided automatically when invoked from compilers that
        /// support CallerMemberName.</param>
        /// <param name="onChanged">Action that is called after the property value has been changed.</param>
        /// <returns>True if the value was changed, false if the existing value matched the
        /// desired value.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);

            return true;
        }
    }

    /// <summary>
    /// Base class for every ViewModel.
    /// This base class can be used, if there is no interface for the model
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class ViewModelBase<TModel> : ViewModelBase<TModel, TModel>
        where TModel : class
    {
    }
}