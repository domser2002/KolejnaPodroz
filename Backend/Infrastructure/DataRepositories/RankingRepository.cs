using Domain.Common;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class RankingRepository(DomainDBContext context) : IRankingRepository
    {
        private readonly DomainDBContext _context = context;
        public bool Add(Ranking ranking)
        {
           _context.Ranking.Add(ranking);
            return _context.SaveChanges()==1;
        }

        public bool Delete(Ranking ranking)
        {
            _context.Ranking.Remove(ranking);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Ranking> GetAll()
        {
            return [.. _context.Ranking];
        }

        public Ranking? GetByCategory(string category)
        {
           return _context.Ranking.FirstOrDefault(a => a.category == category);
        }

        public bool Update(Ranking ranking)
        {
            _context.Ranking.Update(ranking);
            return _context.SaveChanges() == 1;
        }
    }
}
