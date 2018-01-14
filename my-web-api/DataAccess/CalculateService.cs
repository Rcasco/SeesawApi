using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseItApi.Models;

namespace ExpenseItApi.DataAccess
{
	public class CalculateService
	{
        private readonly ExpenseItContext _context;

	    public CalculateService(ExpenseItContext context)
	    {
            _context = context;
	    }

        public CalculationsViewModel Calculate(DateTime startDate, DateTime endDate)
        {
            var calculateVM = new CalculationsViewModel();

            var people = _context.Person.ToList();
            var expenses = _context.Expense.Where(x => x.issuedDate.Date >= startDate.Date &&
                                                   x.issuedDate.Date <= endDate.Date);
            //Get total of all expenses
            calculateVM.totalExpenses = expenses.Sum(x => x.amount);

            //Calculate total expenses for each person
            foreach (var person in people)
            {
                var calculationsPerPerson = new CalculationsPerPersonViewModel()
                {
                    personId = person.id,
                    total = expenses.Where(x => x.personId == person.id).Sum(x => x.amount)
                };
                calculateVM.perPersonCalculations.Add(calculationsPerPerson);
            }

            return calculateVM;
        }
	}
}
