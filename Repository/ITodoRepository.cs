using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using addrbook.Models;

namespace addrbook.Repository
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);

        IEnumerable<TodoItem> GetAll();

        TodoItem Find(string key);

        TodoItem Remove(string key);

        void Update(TodoItem item);
    }
}
