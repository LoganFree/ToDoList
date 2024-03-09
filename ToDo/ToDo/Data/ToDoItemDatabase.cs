using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;
namespace ToDo.Data
{
    internal class TodoItemDatabase
    {
        private readonly SQLiteAsyncConnection _database;
        public TodoItemDatabase(String dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<ToDoItem>();
        }
        public Task<List<ToDoItem>> GetItemsAsync()
        {
            return _database.Table<ToDoItem>().ToListAsync();
        }
        public Task<List<ToDoItem>> GetItemsNotDoneAsync()
        {
            return _database.QueryAsync<ToDoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }
        public Task<ToDoItem> GetItemAsync(int id)
        {
            return _database.Table<ToDoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(ToDoItem item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(ToDoItem item)
        {
            return _database.DeleteAsync(item);
        }
    }
}