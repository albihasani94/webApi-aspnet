using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webApi_aspnet.Models;

namespace webApi_aspnet.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;

            if (_context.ToDoItems.Count() == 0)
            {
                _context.ToDoItems.Add(new ToDoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<ToDoItem> GetAll()
        {
            return _context.ToDoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.ToDoItems.FirstOrDefault(t => t.Id == id);
            return item == null ? (IActionResult) NotFound() : new ObjectResult(item);
        }
    }
}