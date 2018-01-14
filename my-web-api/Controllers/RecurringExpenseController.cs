using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ExpenseItApi.Models;
using ExpenseItApi.DataAccess;
using AutoMapper;

namespace ExpenseItApi.Controllers
{
    [Route("api/RecurringExpense")]
	[EnableCors("AllowAllHeaders")]
	public class RecurringExpenseController : Controller
	{
		private readonly RecurringExpenseService _service;

		public RecurringExpenseController(ExpenseItContext context, IMapper mapper)
		{
            _service = new RecurringExpenseService(context, mapper);
		}

		[HttpGet]
		public IEnumerable<RecurringExpense> GetAll()
		{
            return _service.GetAllRecurringExpenses();
		}

		[HttpGet("{id}", Name = "GetRecurringExpense")]
		public IActionResult GetById(int id)
		{
            var item = _service.GetRecurringExpenseById(id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] RecurringExpense item)
		{
			if (item == null)
			{
				return BadRequest();
			}
            			
            _service.CreateRecurringExpense(item);

			return CreatedAtRoute("GetRecurringExpense", new { id = item.id }, item);
		}

		[HttpPut]
		public IActionResult Update([FromBody] RecurringExpense item)
		{
			if (item == null)
			{
				return BadRequest();
			}

            _service.UpdateRecurringExpense(item);

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_service.DeleteRecurringExpense(id);

			return new NoContentResult();
		}
	}
}