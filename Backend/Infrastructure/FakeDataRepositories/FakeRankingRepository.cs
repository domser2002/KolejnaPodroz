using Domain.Common;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeRankingRepository : IRankingRepository
    {
        private readonly List<Ranking> Rankings = [];
        public bool Add(Ranking ranking)
        {
            Rankings.Add(ranking);
            return true;
        }

        public bool Delete(Ranking ranking)
        {
            Rankings.Remove(ranking);
            return true;
        }

        public IEnumerable<Ranking> GetAll()
        {
            return Rankings;
        }

        public Ranking? GetByCategory(string category)
        {
            return Rankings.FirstOrDefault(a => a.category == category);
        }

        public bool Update(Ranking ranking)
        {
            int index = Rankings.FindIndex(u => u.ID == ranking.ID);
            if (index != -1)
            {
                Rankings.RemoveAt(index);
                Rankings.Add(ranking);
                return true;
            }
            return false;
        }
    }
}
