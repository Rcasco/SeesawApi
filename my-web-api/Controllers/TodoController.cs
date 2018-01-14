using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace TodoApi.Controllers
{
	[Route("api/todo")]
    [EnableCors("AllowAllHeaders")]
	public class TodoController : Controller
	{
		private readonly TodoContext _context;

		public TodoController(TodoContext context)
		{
			_context = context;

			if (_context.TodoItems.Count() == 0)
			{
				_context.TodoItems.Add(new TodoItem 
                { 
                    id = 1,
                    productName = "Item1",
                    unitPrice = 10,
                    unitsInStock = 20,
                    discontinued = true
                });
				_context.SaveChanges();
			}
		}

		[HttpGet]
		public IEnumerable<TodoItem> GetAll()
		{
			return _context.TodoItems.ToList();
		}

		[HttpGet("{id}", Name = "GetTodo")]
		public IActionResult GetById(long id)
		{
			var item = _context.TodoItems.FirstOrDefault(t => t.id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] TodoItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			_context.TodoItems.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetTodo", new { id = item.id }, item);
		}

		[HttpPut]
		public IActionResult Update([FromBody] TodoItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			var todo = _context.TodoItems.FirstOrDefault(t => t.id == item.id);
			if (todo == null)
			{
				return NotFound();
			}

			todo.discontinued = item.discontinued;
            todo.productName = item.productName;
            todo.unitPrice = item.unitPrice;
            todo.unitsInStock = item.unitsInStock;

			_context.TodoItems.Update(todo);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var todo = _context.TodoItems.First(t => t.id == id);
			if (todo == null)
			{
				return NotFound();
			}

			_context.TodoItems.Remove(todo);
			_context.SaveChanges();
			return new NoContentResult();
		}
	}
}