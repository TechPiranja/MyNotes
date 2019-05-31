using Model;
using Model.Interfaces;
using MVVMBase;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase<IMainModel, MainModel>, IMainViewModel
    {
        private readonly INoteTreeViewBuilder _noteTreeViewBuilder;

        public MainViewModel(INoteTreeViewBuilder noteTreeViewBuilder)
        {
            _noteTreeViewBuilder = noteTreeViewBuilder;
            NoteFolder = _noteTreeViewBuilder.Build(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Notes");
        }

        public ICollection<INoteTreeViewModel> NoteFolder
        {
            get => Model.NoteFolder;
            set
            {
                if (value == Model.NoteFolder) return;
                Model.NoteFolder = value; OnPropertyChanged();
            }
        }
    }
}
