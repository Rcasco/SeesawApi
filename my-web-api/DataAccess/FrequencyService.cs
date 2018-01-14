using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ExpenseItApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseItApi.DataAccess
{
    public class FrequencyService
    {
        private readonly ExpenseItContext _context;
        private readonly IMapper _mapper;

        public FrequencyService(ExpenseItContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Frequency> GetAllFrequencies() 
        {
            return _context.Frequency
                                   .AsNoTracking()
                                   .ToList();
        }

        public Frequency GetFrequencyById(int id)
        {
            return _context.Frequency.FirstOrDefault(t => t.id == id);
        }
    }
}
