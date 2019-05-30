using System;
using System.IO;
using System.Reflection;
using ViewModel.Interfaces;

namespace ViewModel.Services
{
    public class NoteSaverService : INoteSaverService
    {
        public NoteSaverService()
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
            var notePath = NoteFolderPath + "\\" + DateTime.Now.ToShortDateString() + ".txt";
            if (!File.Exists(notePath))
                File.CreateText(notePath);

            using (StreamWriter writer = new StreamWriter(notePath, true))
            {
                writer.WriteLine(title);
                writer.WriteLine(note);
                writer.WriteLine();
            }
        }

        private string NoteFolderPath { get; set; }
    }
}
