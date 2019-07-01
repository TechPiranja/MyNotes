﻿using Model;
using Model.Interfaces;
using MVVMBase;
using MVVMBase.MessengerPattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using System.Xml;
using ViewModel.Helper;
using ViewModel.Interfaces;

namespace ViewModel
{
    public class NoteInformationViewModel : ViewModelBase<INoteInformationModel, NoteInformationModel>, INoteInformationViewModel
    {
        private readonly IMessenger _messenger;
        private readonly INoteService _noteService;
        public NoteInformationViewModel(IMessenger messenger, INoteService noteService)
        {
            _messenger = messenger;
            _noteService = noteService;
            DeleteCommand = Factory.Create(p => DeleteNote(p));
            _messenger.Register<NoteTreeViewModel>(this, MessengerConstants.ShowNoteInformation, ShowInformation);
        }

        private void DeleteNote(object p)
        {
            // Todo: cant delete without certain ID
        }

        private void ShowInformation(NoteTreeViewModel noteInfo)
        {
            NoteList = _noteService.GetNotesFromFile(noteInfo.Path);
        }

        public ICollection<INote> NoteList
        {
            get => Model.NoteList;
            set
            {
                if (value == Model.NoteList) return;
                Model.NoteList = value; OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand { get; set; }
    }
}
