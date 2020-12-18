using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TodoList.Models;
using Xamarin.Forms;
using TodoList.Views;
using TodoList.Data;
using Xamarin.Essentials;

namespace TodoList.ViewModels
{
    public class TodoListPageViewModel : BaseFodyObservable
    {
        public string Title => "Just Do It";
        public string EmailBody = "";
        
        private ObservableCollection<Todo> _todoList;
        public ObservableCollection<Todo> TodoList
        {
            get => _todoList;

            set
            {
                if (value != _todoList)
                {
                    _todoList = value;
                }
            }
        }

        private INavigation _navigation;
        public TodoListPageViewModel(INavigation navigation)
        {
            Task.Run(async () => TodoList = new ObservableCollection<Todo>(await App.Database.GetList()));
            _navigation = navigation;
            AddTodo = new Command(async() => await AddTodoItem());
            Delete = new Command<Todo>(DeleteItem);
            ChangeIsDone = new Command<Todo>(ChangeItemIsDone);
            SendEmail = new Command(async () => await SendEmailList());
        }

        async public void PopulateTodoList()
        {
            var tempList = await App.Database.GetList();
            TodoList.Clear();

            foreach (var item in tempList)
            {
                TodoList.Add(item);
                EmailBody += item + " ";
            }
        }
        
        public Command SendEmail { get; set; }
        
        public async Task SendEmailList()
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "My todo list...",
                    Body = EmailBody
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public Command AddTodo { get; set; }

        public async Task AddTodoItem()
        {
            await _navigation.PushModalAsync(new AddTodoPage());
        }
        
        public Command<Todo> Delete { get; set; }

        public async void DeleteItem(Todo item)
        {
            await App.Database.DeleteItem(item);
            PopulateTodoList();
        }

        public Command<Todo> ChangeIsDone { get; set; }

        public async void ChangeItemIsDone(Todo item)
        {
            await App.Database.ChangeItemIsDone(item);
            PopulateTodoList();
        }
    }
}