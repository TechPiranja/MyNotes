using Model.Interfaces;
using System.Collections.Generic;

namespace ViewModel.Interfaces
{
    public interface INoteTreeViewBuilder
    {
        ICollection<INoteTreeViewModel> Build(string folder);
    }
}
