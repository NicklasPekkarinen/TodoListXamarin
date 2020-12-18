using SQLite;
namespace TodoList.Models
{
    public class Todo : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}