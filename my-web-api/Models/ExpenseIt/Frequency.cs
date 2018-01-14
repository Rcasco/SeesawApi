using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseItApi.Models
{
	public class Frequency
	{
		public Frequency() { }

		public int id { get; set; }
		public string name { get; set; }
	}
}
