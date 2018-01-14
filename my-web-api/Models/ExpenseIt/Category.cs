using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseItApi.Models
{
	public class Category
	{
		public Category() { }

		public int id { get; set; }
		public string name { get; set; }
        public DateTime createDate { get; set; } = DateTime.Now;
		public DateTime modifiedDate { get; set; } = DateTime.Now;
	}
}
