using Domain.Common;
using Domain.User;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class StatisticsRepository(DomainDBContext context) : IStatisticsRepository
    {
        private readonly DomainDBContext _context = context;
        public bool Add(Statistics statistics)
        {
            _context.Statistics.Add(statistics);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(Statistics statistics)
        {
            _context.Statistics.Remove(statistics);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Statistics> GetAll()
        {
            return [.. _context.Statistics];

        }

        public List<Statistics>? GetByCategory(int categoryID)
        {
            return _context.Statistics.Where(s => s.CategoryID == categoryID).ToList();
        }

        public List<Statistics>? GetByUser(int userId)
        {
            return _context.Statistics.Where(s => s.UserID == userId).ToList();
        }

        public bool Update(Statistics statistics)
        {
            _context.Statistics.Update(statistics);
            return _context.SaveChanges() == 1;
        }
    }
}
