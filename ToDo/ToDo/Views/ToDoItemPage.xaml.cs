using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDo.Models;
using ToDo;
namespace ToDo.Views
{
    public partial class ToDoItemPage : ContentPage
    {
        public ToDoItemPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            // TodoItemDatabase database = await TodoItemDatabase.Instance;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (ToDoItem)BindingContext;
            //TodoItemDatabase database = await TodoItemDatabase.Instance;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}