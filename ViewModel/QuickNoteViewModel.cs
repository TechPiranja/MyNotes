using Model;
using Model.Interfaces;
using MVVMBase;
using MVVMBase.MessengerPattern;
using System;
using System.Windows.Input;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class QuickNoteViewModel : ViewModelBase<IQuickNoteModel, QuickNoteModel>, IQuickNoteViewModel
    {
        private readonly IMessenger _messenger;
        private readonly INoteSaverService _noteSaverService;
        public QuickNoteViewModel(IMessenger messenger, INoteSaverService noteSaverService)
        {
            _messenger = messenger;
            _noteSaverService = noteSaverService;
            SaveNoteCommand = Factory.Create(p => SaveNote());
        }

        private void SaveNote()
        {
            _noteSaverService.SaveQuickNote(Title, Note);
        }

        public ICommand SaveNoteCommand { get; set; }

        public string Title { get; set; }
        public string Note { get; set; }
    }
}
