using Model;
using Model.Interfaces;
using MVVMBase;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase<IMainModel, MainModel>, IMainViewModel
    {
        private readonly INoteTreeViewBuilder _noteTreeViewBuilder;

        public MainViewModel(INoteTreeViewBuilder noteTreeViewBuilder)
        {
            _noteTreeViewBuilder = noteTreeViewBuilder;

            CloseCommand = Factory.Create(p => Exit());
            CheckNoteFolder();            
        }

        private void CheckNoteFolder()
        {
            var notePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Notes";
            if (!Directory.Exists(notePath))
                Directory.CreateDirectory("Notes");

            NoteFolder = _noteTreeViewBuilder.Build(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Notes");
        }

        private void Exit() => Application.Current.Shutdown();

        public ICollection<INoteTreeViewModel> NoteFolder
        {
            get => Model.NoteFolder;
            set
            {
                if (value == Model.NoteFolder) return;
                Model.NoteFolder = value; OnPropertyChanged();
            }
        }

        public ICommand CloseCommand { get; set; }
    }
}
