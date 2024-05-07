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
        private readonly List<Statistics> Statistics = [];
        public bool Add(Statistics statistics)
        {
            Statistics.Add(statistics);
            return true;
        }

        public bool Delete(Statistics statistics)
        {
            Statistics.Remove(statistics);
            return true;
        }

        public IEnumerable<Statistics> GetAll()
        {
            return Statistics;
        }

        public Statistics? GetByID(int id)
        {
            return Statistics.FirstOrDefault(s => s.ID == id);
        }

        public bool Update(Statistics statistics)
        {
            int index = Statistics.FindIndex(u => u.ID == statistics.ID);
            if (index != -1)
            {
                Statistics.RemoveAt(index);
                Statistics.Add(statistics);
                return true;
            }
            return false;
        }
    }
}
