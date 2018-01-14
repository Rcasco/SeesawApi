using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ExpenseItApi.Models;
using ExpenseItApi.DataAccess;
using AutoMapper;

namespace ExpenseItApi.Controllers
{
    [Route("api/Category")]
	[EnableCors("AllowAllHeaders")]
	public class CategoryController : Controller
	{
		private readonly CategoryService _service;

		public CategoryController(ExpenseItContext context, IMapper mapper)
		{
            _service = new CategoryService(context, mapper);
		}

		[HttpGet]
		public IEnumerable<Category> GetAll()
		{
            return _service.GetAllCategories();
		}

		[HttpGet("{id}", Name = "GetCategory")]
		public IActionResult GetById(int id)
		{
            var item = _service.GetCategoryById(id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] Category item)
		{
			if (item == null)
			{
				return BadRequest();
			}
            			
            _service.CreateCategory(item);

			return CreatedAtRoute("GetCategory", new { id = item.id }, item);
		}

		[HttpPut]
		public IActionResult Update([FromBody] Category item)
		{
			if (item == null)
			{
				return BadRequest();
			}

            _service.UpdateCategory(item);

			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_service.DeleteCategory(id);

			return new NoContentResult();
		}
	}
}