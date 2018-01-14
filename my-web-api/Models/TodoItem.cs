using System;

namespace TodoApi.Models
{
	public class TodoItem
	{
        public TodoItem() {}
		public int id { get; set; }
		public string productName { get; set; }
		public bool discontinued { get; set; }
		public int unitsInStock { get; set; }
		public int unitPrice { get; set; }
	}
}