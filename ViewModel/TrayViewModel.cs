using Model;
using Model.Interfaces;
using MVVMBase;
using MVVMBase.MessengerPattern;
using System.Windows;
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
            OpenMainWindowCommand = Factory.Create(p => _messenger.Send(true, MessengerConstants.OpenMainWindow));
            OpenQuickNoteCommand = Factory.Create(p => _messenger.Send(true, MessengerConstants.OpenQuickNoteDialog));
            ExitCommand = Factory.Create(p => Exit());
        }

        private void Exit() => Application.Current.Shutdown();

        public ICommand OpenMainWindowCommand { get; set; }
        public ICommand OpenQuickNoteCommand { get; set; }
        public ICommand ExitCommand { get; set; }
    }
}
