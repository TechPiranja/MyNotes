using Model.Interfaces;
using System.Collections.Generic;

namespace ViewModel.Interfaces
{
    public interface IMainViewModel
    {
        ICollection<INoteTreeViewModel> NoteFolder { get; set; }
    }
}
