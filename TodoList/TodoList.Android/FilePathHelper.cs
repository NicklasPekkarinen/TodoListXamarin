using System;
using System.IO;
using TodoList.Android;
using TodoList.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePathHelper))]
namespace TodoList.Android
{
    public class FilePathHelper : IFilePathHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}