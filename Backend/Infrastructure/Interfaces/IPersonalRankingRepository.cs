using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User;

namespace Infrastructure.Interfaces
{
    public interface IPersonalRankingRepository
    {
        public IEnumerable<PersonalRanking> GetAll();
        public PersonalRanking? GetByUser(int userId);
        public bool Add(PersonalRanking ranking);
        public bool Update(PersonalRanking ranking);
        public bool Delete(PersonalRanking ranking);
    }
}
