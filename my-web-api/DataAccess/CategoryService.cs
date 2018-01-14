using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ExpenseItApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseItApi.DataAccess
{
    public class CategoryService
    {
        private readonly ExpenseItContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ExpenseItContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories() 
        {
            return _context.Category
                                   .AsNoTracking()
                                   .ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Category.FirstOrDefault(t => t.id == id);
        }

        public void CreateCategory(Category category)
        {
            category.id = 0;
            _context.Category.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = _context.Expense
                                          .AsNoTracking()
                                          .FirstOrDefault(t => t.id == category.id);
            if (categoryToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            _context.Category.Update(category);
            _context.SaveChanges(); 
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Category.FirstOrDefault(t => t.id == id);
            if (category == null)
            {
                throw new ArgumentNullException();
            }
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
    }
}
