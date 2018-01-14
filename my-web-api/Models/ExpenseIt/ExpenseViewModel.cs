using System;
using System.Collections.Generic;

namespace ExpenseItApi.Models
{
	public class ExpenseViewModel
	{
	    public ExpenseViewModel()
	    {
	    }

		public int id { get; set; }
		public string name { get; set; }
		public double amount { get; set; }
		public bool shared { get; set; }
		public DateTime issuedDate { get; set; } = DateTime.Now;
		public DateTime createDate { get; set; } = DateTime.Now;
		public DateTime modifiedDate { get; set; } = DateTime.Now;

		public int personId { get; set; }
		public string personName { get; set; }

		public int? recurringExpenseId { get; set; }
		public string recurringExpenseName { get; set; }

		public int? categoryId { get; set; }
		public string categoryName { get; set; }
	}
}
