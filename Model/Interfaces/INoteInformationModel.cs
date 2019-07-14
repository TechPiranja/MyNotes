using System.Collections.Generic;

namespace Model.Interfaces
{
    public interface INoteInformationModel
    {
        ICollection<INote> NoteList { get; set; }
        string NotePath { get; set; }
    }
}
