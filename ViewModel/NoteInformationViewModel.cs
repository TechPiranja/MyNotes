﻿using Model;
using Model.Interfaces;
using MVVMBase;
using MVVMBase.MessengerPattern;
using System;
using System.Collections.Generic;
using System.Windows.Input;
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
            _messenger.Register<bool>(this, MessengerConstants.RefreshNoteList, RefreshNoteList);
        }

        private void RefreshNoteList(bool test)
        {
            NoteList = _noteService.GetNotesFromFile(NotePath);
        }

        private void DeleteNote(object p)
        {
            _noteService.DeleteNote(NotePath, (string)p);
            NoteList = _noteService.GetNotesFromFile(NotePath);
        }

        private void ShowInformation(NoteTreeViewModel noteInfo)
        {
            NoteList = _noteService.GetNotesFromFile(noteInfo.Path);
            NotePath = noteInfo.Path;
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

        public string NotePath
        {
            get => Model.NotePath;
            set
            {
                if (value == Model.NotePath) return;
                Model.NotePath = value; OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand { get; set; }
    }
}
