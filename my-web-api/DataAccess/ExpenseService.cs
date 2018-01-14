using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ExpenseItApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseItApi.DataAccess
{
    public class ExpenseService
    {
        private readonly ExpenseItContext _context;
        private readonly IMapper _mapper;

        public ExpenseService(ExpenseItContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

            //initialize for testing
            if (_context.Expense.Count() == 0)
            {
                var category = new Category()
                {
                    name = "Mortgage"
                };
                _context.Category.Add(category);
                var category2 = new Category()
                {
                    name = "Restaurant"
                };
                _context.Category.Add(category2);
                var person = new Person()
                {
                    name = "Roger"
                };
                _context.Person.Add(person);
				var person2 = new Person()
				{
					name = "Rosa"
				};
				_context.Person.Add(person2);
                _context.Expense.Add(new Expense
                {
                    name = "Item1",
                    amount = 10,
                    shared = true,
                    category = category,
                    person = person                   
                });
				_context.Expense.Add(new Expense
                {
                    name = "Item2",
                    amount = 20,
                    shared = false,
					category = category2,
					person = person2
				});
                _context.SaveChanges();
            }
        }

        public IEnumerable<Expense> GetAllExpenses() 
        {
            return _context.Expense
                                   .Include(x => x.person)
                                   .Include(x => x.category)
                                   .AsNoTracking()
                                   .ToList();
        }

        public Expense GetExpenseById(int id)
        {
            return _context.Expense.FirstOrDefault(t => t.id == id);
        }

        public void CreateExpense(Expense expense)
        {
            expense.id = 0;
            _context.Expense.Add(expense);
            _context.SaveChanges();
        }

        public void UpdateExpense(Expense expense)
        {
            var expenseToUpdate = _context.Expense
                                          .AsNoTracking()
                                          .FirstOrDefault(t => t.id == expense.id);
            if (expenseToUpdate == null)
            {
                throw new ArgumentNullException();
            }
            //ensure we are only saving the date part
            expense.issuedDate = expense.issuedDate.Date;

            _context.Expense.Update(expense);
            _context.SaveChanges(); 
        }

        public void DeleteExpense(int id)
        {
            var expense = _context.Expense.FirstOrDefault(t => t.id == id);
            if (expense == null)
            {
                throw new ArgumentNullException();
            }
            _context.Expense.Remove(expense);
            _context.SaveChanges();
        }
    }
}
