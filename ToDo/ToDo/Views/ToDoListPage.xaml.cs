using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data;
using ToDo.Models;
using ToDo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Views
{
    public partial class ToDoListPage : ContentPage
    {
        public ToDoListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //TodoItemDatabase database = await TodoItemDatabase.Instance;
            listView.ItemsSource = await App.Database.GetItemsAsync();

        }
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDoItemPage
            {
                BindingContext = new ToDoItem()
            });
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ToDoItemPage
                {
                    BindingContext = e.SelectedItem as ToDoItem
                });
            }
        }
    }
}