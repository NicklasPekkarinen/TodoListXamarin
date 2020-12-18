using Xamarin.Forms;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class AddTodoPageViewModel : BaseFodyObservable
    {
        private INavigation _navigation;
        private string _todoTitle;

        public string TodoTitle
        {
            get => _todoTitle;
            set
            {
                _todoTitle = value;
                OnPropertyChanged(nameof(TodoTitle));
            }
        }
        public Command Save { get; set; }

        public async void SaveItem()
        {
            await App.Database.AddItem(new Todo {Title = _todoTitle});
            await _navigation.PopModalAsync();
        }
        public Command Cancel { get; set; }

        public async void CancelSaveItem()
        {
            await _navigation.PopModalAsync();
        }
        public AddTodoPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Save = new Command(SaveItem);
            Cancel = new Command(CancelSaveItem);
        }
    }
}