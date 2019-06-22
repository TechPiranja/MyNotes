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
            if (!Directory.Exists(NoteFolderPath))
                Directory.CreateDirectory("Notes");
        }

        public void SaveQuickNote(string title, string note)
        {
            var notePath = NoteFolderPath + "\\" + DateTime.Now.ToShortDateString() + ".xml";

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
            noteNode.InnerText = note;
            notesNode.AppendChild(noteNode);

            xmlDoc.Save(notePath);
        }

        public ICollection<INote> GetNotesFromFile(string path)
        {
            var noteList = new Collection<INote>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList noteNode = xmlDoc.SelectNodes("//notes/note");

            foreach (XmlNode note in noteNode)
            {
                var noteItem = new Note
                {
                    Title = note.Attributes["title"].Value,
                    Content = note.Attributes["title"].InnerText
                };

                noteList.Add(noteItem);
            }

            return noteList;
        }

        private string NoteFolderPath { get; set; }
    }
}
