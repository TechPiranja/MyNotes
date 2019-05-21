using MVVMBase.MessengerPattern;
using MyNotes;
using View.Dialogs;
//using View.Dialogs;
using View.Service.Interfaces;
using ViewModel.Helper;

namespace View.Service
{
    public class DialogService : IDialogService
    {
        private MainWindow _mainWindow;
        private QuickNote _quickNote;
        private readonly IMessenger _messenger;

        public DialogService(IMessenger messenger)
        {
            _messenger = messenger;
            _messenger.Register<bool>(this, MessengerConstants.OpenMainWindow, p => ShowMainWindow());
            _messenger.Register<bool>(this, MessengerConstants.OpenQuickNoteDialog, p => ShowQuickNoteDialog());
            //_messenger.Register<bool>(this, MessengerConstants.CloseGetConfigDialog, p => _getConfigDialog?.Close());
        }

        public void ShowMainWindow()
        {
            _mainWindow = new MainWindow();
            _mainWindow.Show();
        }

        public void ShowQuickNoteDialog()
        {
            _quickNote = new QuickNote();
            _quickNote.ShowDialog();
        }
    }
}
