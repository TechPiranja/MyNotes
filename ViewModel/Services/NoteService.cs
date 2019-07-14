using Model;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
            XmlAttribute attribute2 = xmlDoc.CreateAttribute("noteId");
            attribute.Value = title;
            attribute2.Value = DateTime.Now.Ticks.ToString();
            noteNode.Attributes.Append(attribute);
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
            XmlNodeList nodeList = xmlDoc.SelectNodes("//notes/note");

            foreach (XmlNode note in nodeList)
            {
                var noteItem = new Note
                {
                    Title = note.Attributes["title"].Value,
                    NoteId = note.Attributes["noteId"].Value,
                    Content = note.InnerText
                };

                noteList.Add(noteItem);
            }

            return noteList;
        }

        public void DeleteNote(string path, string noteId)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNode node = xmlDoc.SelectSingleNode($"/notes/note[@noteId='{noteId}']");            
            node.ParentNode.RemoveChild(node);
            xmlDoc.Save(path);
        }

        private string NoteFolderPath { get; set; }
        private string NoteYearPath { get; set; }
        private string NoteMonthPath { get; set; }
    }
}
