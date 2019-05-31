using Model.Interfaces;
using System.Collections.Generic;

namespace Model
{
    public class MainModel : IMainModel
    {
        public ICollection<INoteTreeViewModel> NoteFolder { get; set; }
    }
}
