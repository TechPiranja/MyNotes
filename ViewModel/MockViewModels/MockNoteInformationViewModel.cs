using System.Collections.Generic;
using Model.Interfaces;
using ViewModel.Interfaces;

namespace ViewModel.MockViewModels
{
    public class MockNoteInformationViewModel : INoteInformationViewModel
    {
        public ICollection<INote> NoteList { get; set; }
    }
}
