using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using TodoList.Models;

namespace TodoList.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _db;
       
        public Database()
        {
            _db = new SQLiteAsyncConnection(DependencyService.Get<IFilePathHelper>().GetLocalFilePath("TodoListSQLite.db3"));
            _db.CreateTableAsync<Todo>().Wait();
        }

        public async Task<List<Todo>> GetList()
        {
            return await _db.Table<Todo>().ToListAsync();
        }

        public Task DeleteItem(Todo item)
        {
            return _db.DeleteAsync(item);
        }

        public Task ChangeItemIsDone(Todo item)
        {
            item.IsDone = !item.IsDone;
            return _db.UpdateAsync(item);
        }
        
        public Task AddItem(Todo item)
        {
            return _db.InsertAsync(item);
        }
    }
}