using System;
using ToDo.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using ToDo.Views;
namespace ToDo
{
    public partial class App : Application
    {
        private static TodoItemDatabase database;
        internal static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.LocalApplicationData), "TodoListItems.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ToDoListPage());
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}