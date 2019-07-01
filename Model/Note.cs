using Model.Interfaces;

namespace Model
{
    public class Note : INote
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string NoteId { get; set; }
    }
}
