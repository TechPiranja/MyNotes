namespace Model.Interfaces
{
    public interface INote
    {
        string NoteId { get; set; }
        string Title { get; set; }
        string Content { get; set; }        
    }
}
