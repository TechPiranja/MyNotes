using System.Collections.Generic;
using Model.Interfaces;

namespace Model
{
    public class NoteInformationModel : INoteInformationModel
    {
        public ICollection<INote> NoteList { get; set; }
        public string NotePath { get; set; }
    }
}
