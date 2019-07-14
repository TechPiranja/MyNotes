using Model.Interfaces;
using System.Collections.Generic;

namespace ViewModel.Interfaces
{
    public interface INoteService
    {
        void SaveQuickNote(string title, string note);
        ICollection<INote> GetNotesFromFile(string path);
        void DeleteNote(string path, string noteId);
    }
}
