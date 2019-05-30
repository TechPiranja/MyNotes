using Model.Interfaces;

namespace Model
{
    public class QuickNoteModel : IQuickNoteModel
    {
        public string Title { get; set; }
        public string Note { get; set; }
    }
}
