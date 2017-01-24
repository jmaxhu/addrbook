using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using addrbook.Models;
using addrbook.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace addrbook.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public ITodoRepository TodoRepository { get; set; }

        public TodoController(ITodoRepository todoRepository) {
            TodoRepository = todoRepository;
        }

        // GET api/todo
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoRepository.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetByKey(string id)
        {
            var item = TodoRepository.Find(id);
            if (item == null) {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item) {
            if (item == null) {
                return BadRequest();
            }
            TodoRepository.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        } 

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item) {
            if (item == null || item.Key != id) {
                return BadRequest();
            }
            var todo = TodoRepository.Find(id);
            if (todo == null) {
                return NotFound();
            }
            TodoRepository.Update(item);
            return new NoContentResult();
        }

        [HttpDeleteAttribute("{id}")]
        public IActionResult Delete(string id) {
           var todo = TodoRepository.Find(id);
           if (todo == null) {
               return NotFound();
           } 
           TodoRepository.Remove(id);
           return new NoContentResult();
        }
    }
}
