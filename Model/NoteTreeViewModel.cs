using Model.Interfaces;
using System;
using System.Collections.Generic;

namespace Model
{
    public class NoteTreeViewModel : INoteTreeViewModel
    {
        public string ImageSource { get; set; }
        public ICollection<INoteTreeViewModel> Items { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
