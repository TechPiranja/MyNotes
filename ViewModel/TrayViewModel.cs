using Model;
using Model.Interfaces;
using MVVMBase;
using MVVMBase.MessengerPattern;
using System;
using System.Windows.Input;
using ViewModel.Helper;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class TrayViewModel : ViewModelBase<ITrayModel, TrayModel>, ITrayViewModel
    {
        private readonly IMessenger _messenger;
        public TrayViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            OpenMainWindowCommand = Factory.Create(p => OpenMainWindow());
        }

        private void OpenMainWindow()
        {
            _messenger.Send(true, MessengerConstants.OpenMainWindow);
        }

        public ICommand OpenMainWindowCommand { get; set; }
    }
}
