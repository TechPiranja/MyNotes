using Model;
using Model.Interfaces;
using MVVMBase;
using MVVMBase.MessengerPattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using ViewModel.Helper;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase<IMainModel, MainModel>, IMainViewModel
    {
        private readonly INoteTreeViewBuilder _noteTreeViewBuilder;
        private readonly IMessenger _messenger;

        public MainViewModel(INoteTreeViewBuilder noteTreeViewBuilder, IMessenger messenger)
        {
            _noteTreeViewBuilder = noteTreeViewBuilder;
            _messenger = messenger;
            CloseCommand = Factory.Create(p => Exit());
            GetNoteInformationCommand = Factory.Create(p => GetNoteInformation(p));
            CheckNoteFolder();
        }

        private void GetNoteInformation(object p)
        {
            var noteInformation = (NoteTreeViewModel)p;
            _messenger.Send(noteInformation, MessengerConstants.ShowNoteInformation);
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

        public ICommand GetNoteInformationCommand { get; set; }
    }
}
