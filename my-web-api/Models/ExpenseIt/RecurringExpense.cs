using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseItApi.Models
{
	public class RecurringExpense
	{
		public RecurringExpense() { }

		public int id { get; set; }
		public string name { get; set; }
        public decimal amount { get; set; }
        public bool covered { get; set; } 
		public DateTime createDate { get; set; } = DateTime.Now;
		public DateTime modifiedDate { get; set; } = DateTime.Now;

		public int personId { get; set; }
		public virtual Person person { get; set; }
        public int frequencyId { get; set; }
        public virtual Frequency frequency { get; set; }
	}
}
