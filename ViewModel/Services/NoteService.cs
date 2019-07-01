using Model;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Xml;
using ViewModel.Interfaces;

namespace ViewModel.Services
{
    public class NoteService : INoteService
    {
        public NoteService()
        {
            CheckNoteFolder();
        }

        private void CheckNoteFolder()
        {
            NoteFolderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Notes";
            NoteYearPath = NoteFolderPath + "\\" + DateTime.Now.Year.ToString();
            NoteMonthPath = NoteYearPath + "\\" + DateTime.Now.ToString("MMM");

            if (!Directory.Exists(NoteFolderPath))
                Directory.CreateDirectory("Notes");
            if (!Directory.Exists(NoteYearPath))
                Directory.CreateDirectory(NoteYearPath);
            if (!Directory.Exists(NoteMonthPath))
                Directory.CreateDirectory(NoteMonthPath);
        }

        public void SaveQuickNote(string title, string note)
        {
            var notePath = NoteMonthPath + "\\" + DateTime.Now.ToShortDateString() + ".xml";

            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(notePath))
            {
                xmlDoc.Load(notePath);
            }
            else
            {
                XmlNode rootNode = xmlDoc.CreateElement("notes");
                xmlDoc.AppendChild(rootNode);
            }

            XmlNode notesNode = xmlDoc.SelectSingleNode("//notes");
            XmlNode noteNode = xmlDoc.CreateElement("note");

            XmlAttribute attribute = xmlDoc.CreateAttribute("title");
            attribute.Value = title;
            noteNode.Attributes.Append(attribute);

            XmlAttribute attribute2 = xmlDoc.CreateAttribute("noteId");
            attribute2.Value = DateTime.Now.Ticks.ToString();
            noteNode.Attributes.Append(attribute2);

            noteNode.InnerText = note;
            notesNode.AppendChild(noteNode);

            xmlDoc.Save(notePath);
        }

        public ICollection<INote> GetNotesFromFile(string path)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                return null;

            var noteList = new Collection<INote>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList noteNode = xmlDoc.SelectNodes("//notes/note");

            foreach (XmlNode note in noteNode)
            {
                var noteItem = new Note
                {
                    NoteId = note.Attributes["noteId"].Value,
                    Title = note.Attributes["title"].Value,
                    Content = note.InnerText
                };

                noteList.Add(noteItem);
            }

            return noteList;
        }

        private string NoteFolderPath { get; set; }
        private string NoteYearPath { get; set; }
        private string NoteMonthPath { get; set; }
    }
}
