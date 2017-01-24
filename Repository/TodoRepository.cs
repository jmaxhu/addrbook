using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using addrbook.Models;

namespace addrbook.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, TodoItem> _todos = 
            new ConcurrentDictionary<string, TodoItem>(); 

        public TodoRepository()
        {
        }

        public void Add(TodoItem item) {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public IEnumerable<TodoItem> GetAll() {
            return _todos.Values;
        }

        public TodoItem Remove(string key) {
            TodoItem item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public TodoItem Find(string key) {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public void Update(TodoItem item) {
            _todos[item.Key] = item;
        }
    }
}
