using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ExpenseItApi.Models;
using ExpenseItApi.DataAccess;
using AutoMapper;

namespace ExpenseItApi.Controllers
{
    [Route("api/Person")]
	[EnableCors("AllowAllHeaders")]
	public class PersonController : Controller
	{
		private readonly PersonService _service;

		public PersonController(ExpenseItContext context, IMapper mapper)
		{
            _service = new PersonService(context, mapper);
		}

		[HttpGet]
		public IEnumerable<Person> GetAll()
		{
            return _service.GetAllPeople();
		}

		[HttpGet("{id}", Name = "GetPerson")]
		public IActionResult GetById(int id)
		{
            var item = _service.GetPersonById(id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Person item)
		{
			if (item == null)
			{
				return BadRequest();
			}
            			
            _service.CreatePerson(item);

			return CreatedAtRoute("GetPerson", new { id = item.id }, item);
		}

		[HttpPut]
		public IActionResult Update([FromBody] Person item)
		{
			if (item == null)
			{
				return BadRequest();
			}

            _service.UpdatePerson(item);

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_service.DeletePerson(id);

			return new NoContentResult();
		}
	}
}