using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ExpenseItApi.Models;
using ExpenseItApi.DataAccess;
using AutoMapper;

namespace ExpenseItApi.Controllers
{
    [Route("api/ExpenseIt")]
	[EnableCors("AllowAllHeaders")]
	public class ExpenseItController : Controller
	{
		private readonly ExpenseService _service;

		public ExpenseItController(ExpenseItContext context, IMapper mapper)
		{
            _service = new ExpenseService(context, mapper);
		}

        [HttpGet]
        public IEnumerable<Expense> GetAll()
        {
            return _service.GetAllExpenses();
        }

		[HttpGet("{id}", Name = "GetExpense")]
		public IActionResult GetById(int id)
		{
            var item = _service.GetExpenseById(id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Expense item)
		{
			if (item == null)
			{
				return BadRequest();
			}
            			
            _service.CreateExpense(item);

			return CreatedAtRoute("GetExpense", new { id = item.id }, item);
		}

		[HttpPut]
		public IActionResult Update([FromBody] Expense item)
		{
			if (item == null)
			{
				return BadRequest();
			}

            _service.UpdateExpense(item);

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_service.DeleteExpense(id);

			return new NoContentResult();
		}
	}
}