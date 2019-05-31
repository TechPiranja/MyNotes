using Model;
using Model.Interfaces;
using System.Collections.Generic;
using System.IO;
using ViewModel.Interfaces;

namespace ViewModel.Builder
{
    public class NoteTreeViewBuilder : INoteTreeViewBuilder
    {
        public ICollection<INoteTreeViewModel> Build(string folder)
        {
            var result = new List<INoteTreeViewModel>();
            var allFiles = Directory.GetFiles(folder);
            var allDirectorys = Directory.GetDirectories(folder);

            foreach (var dir in allDirectorys)
            {
                var model = new NoteTreeViewModel();
                model.Name = Path.GetFileNameWithoutExtension(dir);
                model.ImageSource = GetImage(dir);
                model.Items = Build(dir);
                model.Path = dir;
                result.Add(model);
            }

            foreach (var file in allFiles)
            {
                var model = new NoteTreeViewModel();
                model.Name = Path.GetFileNameWithoutExtension(file);
                model.ImageSource = GetImage(file);
                model.Path = file;
                result.Add(model);
            }

            return result;
        }

        private string GetImage(string folder)
        {
            return File.GetAttributes(folder).HasFlag(FileAttributes.Directory) ? "FolderOpen" : "File";
        }
    }
}
