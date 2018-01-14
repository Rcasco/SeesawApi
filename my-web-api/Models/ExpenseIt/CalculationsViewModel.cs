using System;
using System.Collections.Generic;

namespace ExpenseItApi.Models
{
	public class CalculationsViewModel
	{
        public decimal totalExpenses { get; set; }
        public List<CalculationsPerPersonViewModel> perPersonCalculations { get; set; } 
            = new List<CalculationsPerPersonViewModel>();
	}
}
