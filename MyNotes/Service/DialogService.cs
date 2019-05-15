using MVVMBase.MessengerPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using View.Dialogs;
using View.Service.Interfaces;
using ViewModel.Helper;
using ViewModel.Interfaces;

namespace View.Service
{
    public class DialogService : IDialogService
    {
        //private DialogName _getConfigDialog;
        private readonly IMessenger _messenger;

        public DialogService(IMessenger messenger)
        {
            _messenger = messenger;
            //_messenger.Register<string>(this, MessengerConstants.OpenGetConfigDialog, p => ShowGetConfigDialog(p));
            //_messenger.Register<bool>(this, MessengerConstants.CloseGetConfigDialog, p => _getConfigDialog?.Close());
        }

        public void ShowGetConfigDialog(string path)
        {
            //_getConfigDialog = new GetConfig();
            //((IGetConfigViewModel)_getConfigDialog.DataContext).ToolPath = path;
            //_getConfigDialog.ShowDialog();
        }
    }
}
