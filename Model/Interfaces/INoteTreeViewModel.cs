using System.Collections.Generic;

namespace Model.Interfaces
{
    public interface INoteTreeViewModel
    {
        string ImageSource { get; set; }
        ICollection<INoteTreeViewModel> Items { get; set; }
        string Name { get; set; }
        string Path { get; set; }
    }
}
