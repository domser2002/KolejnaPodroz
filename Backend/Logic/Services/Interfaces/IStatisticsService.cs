using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IStatisticsService
    {
        public List<Statistics> GetByUser(int userID);
        public bool Update(int userID, Statistics statistics);
    }
}
