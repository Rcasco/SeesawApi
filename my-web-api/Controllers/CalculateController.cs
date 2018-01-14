using System;
using ExpenseItApi.DataAccess;
using ExpenseItApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseItApi.Controllers
{
	[Route("api/Calculate")]
	[EnableCors("AllowAllHeaders")]
	public class CalculateController
	{
        private readonly CalculateService _service;

	    public CalculateController(ExpenseItContext context)
	    {
            _service = new CalculateService(context);
	    }

		[HttpGet]
		public CalculationsViewModel Calculate(DateTime startDate, DateTime endDate)
		{
            return _service.Calculate(startDate, endDate);
		}
	}
}
