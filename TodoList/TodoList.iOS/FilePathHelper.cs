using System;
using System.IO;
using TodoList.Data;
using TodoList.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePathHelper))]
namespace TodoList.iOS
{
    public class FilePathHelper : IFilePathHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}