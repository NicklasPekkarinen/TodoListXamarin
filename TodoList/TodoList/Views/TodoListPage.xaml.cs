using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
            BindingContext = new TodoListPageViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var pageVm = this.BindingContext as TodoListPageViewModel;

            if (pageVm != null)
            {
                pageVm.PopulateTodoList();
            }
        }
    }
}