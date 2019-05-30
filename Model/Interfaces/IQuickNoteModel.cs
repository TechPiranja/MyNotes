using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IQuickNoteModel
    {
        string Title { get; set; }
        string Note { get; set; }
    }
}
