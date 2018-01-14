using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseItApi.Models
{
	public class Expense
	{
		public Expense() { }

		public int id { get; set; }
		public string name { get; set; }
        public decimal amount { get; set; }
        public bool shared { get; set; }
        public DateTime issuedDate { get; set; } = DateTime.Now.Date;
		public DateTime createDate { get; set; } = DateTime.Now;
		public DateTime modifiedDate { get; set; } = DateTime.Now;

        public int personId { get; set; }
        public virtual Person person { get; set; }

        public int? categoryId { get; set; }
        public virtual Category category { get; set; }
	}
}
