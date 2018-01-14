using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ExpenseItApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseItApi.DataAccess
{
    public class RecurringExpenseService
    {
        private readonly ExpenseItContext _context;
        private readonly IMapper _mapper;

        public RecurringExpenseService(ExpenseItContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

            if (!_context.RecurringExpense.Any())
            {
                Person person, person2;
                Frequency f1, f2;
                if(!_context.Person.Any())
                {
					person = new Person()
					{
						name = "Roger"
					};
					_context.Person.Add(person);
					person2 = new Person()
					{
						name = "Rosa"
					};
					_context.Person.Add(person2);
                    _context.SaveChanges();
                }
                else 
                {
                    person = _context.Person.First();
                    person2 = _context.Person.Skip(1).First();
                }
                if(!_context.Frequency.Any())
                {
                    f1 = new Frequency()
                    {
                        name = "Monthly"
                    };
                    _context.Frequency.Add(f1);
                    f2 = new Frequency()
                    {
                        name = "Bi-Monthly"
                    };
                    _context.Frequency.Add(f2);
                    _context.SaveChanges();
                } 
                else
				{
                    f1 = _context.Frequency.First();
                    f2 = _context.Frequency.Skip(1).First();
				}
                var recurringExpense = new RecurringExpense()
                {
                    name = "Mortgage",
                    person = person,
                    frequency = f1,
                    amount = 1000,
                    covered = true
                };
                _context.RecurringExpense.Add(recurringExpense);
                var recurringExpense2 = new RecurringExpense()
                {
                    name = "Car Payment",
                    person = person2,
                    frequency = f2,
                    amount = 500,
                    covered = false
                };
				_context.RecurringExpense.Add(recurringExpense2);
				_context.SaveChanges();
            }
        }

        public IEnumerable<RecurringExpense> GetAllRecurringExpenses() 
        {
            return _context.RecurringExpense
                                   .AsNoTracking()
                                   .ToList();
        }

        public RecurringExpense GetRecurringExpenseById(int id)
        {
            return _context.RecurringExpense.FirstOrDefault(t => t.id == id);
        }

        public void CreateRecurringExpense(RecurringExpense item)
        {
            item.id = 0;
            _context.RecurringExpense.Add(item);
            _context.SaveChanges();
        }

        public void UpdateRecurringExpense(RecurringExpense expense)
        {
            var expenseToUpdate = _context.Expense
                                          .AsNoTracking()
                                          .FirstOrDefault(t => t.id == expense.id);
            if (expenseToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            _context.RecurringExpense.Update(expense);
            _context.SaveChanges(); 
        }

        public void DeleteRecurringExpense(int id)
        {
            var expense = _context.RecurringExpense.FirstOrDefault(t => t.id == id);
            if (expense == null)
            {
                throw new ArgumentNullException();
            }
            _context.RecurringExpense.Remove(expense);
            _context.SaveChanges();
        }
    }
}
