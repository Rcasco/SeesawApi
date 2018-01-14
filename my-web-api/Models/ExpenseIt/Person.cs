using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseItApi.Models
{
	public class Person
	{
		public Person() { }

		public int id { get; set; }
		public string name { get; set; }
		public DateTime createDate { get; set; } = DateTime.Now;
        public DateTime modifiedDate { get; set; } = DateTime.Now;
	}
}
