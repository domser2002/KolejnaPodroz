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
    public class FakeStatisticsRepository : IStatisticsRepository
    {
        private readonly List<Statistics> Statisticss;
        public bool Add(Statistics statistics)
        {
            Statisticss.Add(statistics);
            return true;
        }

        public bool Delete(Statistics statistics)
        {
            Statisticss.Remove(statistics);
            return true;
        }

        public IEnumerable<Statistics> GetAll()
        {
            return Statisticss;
        }

        public Statistics? GetByUser(int userId)
        {
            return Statisticss.FirstOrDefault(a => a.UserID == userId);
        }

        public bool Update(Statistics statistics)
        {
            int index = Statisticss.FindIndex(u => u.ID == statistics.ID);
            if (index != -1)
            {
                Statisticss.RemoveAt(index);
                Statisticss.Add(statistics);
                return true;
            }
            return false;
        }
    }
}
