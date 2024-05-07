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
        public List<Statistics>? GetByUser(int userID);
        public List<Statistics>? GetByCategory(int categoryID);
        public bool Update(Statistics statistics);
    }
}
