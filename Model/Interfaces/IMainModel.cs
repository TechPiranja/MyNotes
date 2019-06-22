using System.Collections.Generic;

namespace Model.Interfaces
{
    public interface IMainModel
    {
        ICollection<INoteTreeViewModel> NoteFolder { get; set; }
        object SelectedNoteFile { get; set; }
    }
}
