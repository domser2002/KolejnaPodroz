using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Infrastructure.Interfaces
{
    public interface IRankingRepository
    {
        public IEnumerable<Ranking> GetAll();
        public Ranking? GetByCategory(string category);
        public bool Add(Ranking ranking);
        public bool Update(Ranking ranking);
        public bool Delete(Ranking ranking);    
    }
}
