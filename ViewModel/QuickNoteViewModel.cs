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
    public class QuickNoteViewModel : ViewModelBase<IQuickNoteModel, QuickNoteModel>, IQuickNoteViewModel
    {
        private readonly IMessenger _messenger;
        private readonly INoteService _noteService;
        public QuickNoteViewModel(IMessenger messenger, INoteService noteSerivce)
        {
            _messenger = messenger;
            _noteService = noteSerivce;
            SaveNoteCommand = Factory.Create(p => SaveNote());
        }

        private void SaveNote()
        {
            _noteService.SaveQuickNote(Title, Note);
            _messenger.Send(true, MessengerConstants.RefreshNoteList);
        }

        public ICommand SaveNoteCommand { get; set; }

        public string Title { get; set; }
        public string Note { get; set; }
    }
}
