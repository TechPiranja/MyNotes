using Model.Interfaces;
using System.Collections.Generic;

namespace ViewModel.Interfaces
{
    public interface INoteInformationViewModel
    {
        ICollection<INote> NoteList { get; set; }
    }
}
