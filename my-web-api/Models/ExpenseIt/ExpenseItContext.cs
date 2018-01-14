using Microsoft.EntityFrameworkCore;

namespace ExpenseItApi.Models
{
	public class ExpenseItContext : DbContext
	{
		public ExpenseItContext(DbContextOptions<ExpenseItContext> options)
			: base(options)
		{
		}
		public DbSet<Expense> Expense { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<RecurringExpense> RecurringExpense { get; set; }
		public DbSet<Frequency> Frequency { get; set; }
	}
}
