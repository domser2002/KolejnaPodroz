using Domain.Common;
using Domain.User;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakePersonalRankingRepository : IPersonalRankingRepository
    {
        private readonly List<PersonalRanking> PersonalRankings = [];
        public bool Add(PersonalRanking ranking)
        {
            PersonalRankings.Add(ranking) ;
            return true;
        }

        public bool Delete(PersonalRanking ranking)
        {
            PersonalRankings.Remove(ranking);
            return true;
        }

        public IEnumerable<PersonalRanking> GetAll()
        {
            return PersonalRankings;
        }

        public PersonalRanking? GetByUser(int userId)
        {
            return PersonalRankings.FirstOrDefault(a => a.UserID == userId);
        }

        public bool Update(PersonalRanking ranking)
        {
            int index = PersonalRankings.FindIndex(u => u.ID == ranking.ID);
            if (index != -1)
            {
                PersonalRankings.RemoveAt(index);
                PersonalRankings.Add(ranking);
                return true ;
            }
            return false;
        }
    }
}
