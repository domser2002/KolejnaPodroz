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
    public class PersonalRankingRepository(DomainDBContext context) : IPersonalRankingRepository
    {
        private readonly DomainDBContext _context = context;
        public bool Add(PersonalRanking ranking)
        {
            _context.PersonalRanking.Add(ranking);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(PersonalRanking ranking)
        {
            _context.PersonalRanking.Remove(ranking);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<PersonalRanking> GetAll()
        {
            return [.. _context.PersonalRanking];
        }

        public PersonalRanking? GetByUser(int userId)
        {
            return _context.PersonalRanking.FirstOrDefault(a => a.UserID == userId);
        }

        public bool Update(PersonalRanking ranking)
        {
           _context.PersonalRanking.Update(ranking);
            return _context.SaveChanges() == 1;
        }
    }
}
