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
        public int Add(Statistics statistics)
        {
            //int id = !GetAll().Any() ? 1 : GetAll().Max(x => x.ID) + 1;
            //statistics.ID = id; // temporary solution
            _context.Statistics.Add(statistics);
            return (_context.SaveChanges() == 1) ? statistics.ID : -1;
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

        public Statistics? GetByID(int id)
        {
            return _context.Statistics.FirstOrDefault(s => s.ID == id);
        }

        public bool Update(Statistics statistics)
        {
            _context.Statistics.Update(statistics);
            return _context.SaveChanges() == 1;
        }
    }
}
