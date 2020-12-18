using System;
using System.IO;
using SQLite;

namespace TodoList
{
    public class Constants
    {
        public const string DatabaseFileName = "TodoListSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public string DatabasePath
        {
            get
            {
                var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }
    }
}