using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ExpenseItApi.Models;
using ExpenseItApi.DataAccess;
using AutoMapper;

namespace ExpenseItApi.Controllers
{
    [Route("api/Frequency")]
	[EnableCors("AllowAllHeaders")]
	public class FrequencyController : Controller
	{
		private readonly FrequencyService _service;

		public FrequencyController(ExpenseItContext context, IMapper mapper)
		{
            _service = new FrequencyService(context, mapper);
		}

		[HttpGet]
		public IEnumerable<Frequency> GetAll()
		{
            return _service.GetAllFrequencies();
		}

		[HttpGet("{id}", Name = "GetFrequency")]
		public IActionResult GetById(int id)
		{
            var item = _service.GetFrequencyById(id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}
	}
}