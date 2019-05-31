using System.Collections.Generic;
using Model.Interfaces;
using ViewModel.Interfaces;

namespace ViewModel.MockViewModels
{
    public class MockMainViewModel : IMainViewModel
    {
        public ICollection<INoteTreeViewModel> NoteFolder { get; set; }
    }
}
