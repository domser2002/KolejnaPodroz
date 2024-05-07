﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IStatisticsRepository
    {
        public IEnumerable<Statistics> GetAll();
        public List<Statistics>? GetByUser(int userId);
        public List<Statistics>? GetByCategory(int categoryID);
        public bool Add(Statistics statistics);
        public bool Update(Statistics statistics);
        public bool Delete(Statistics statistics);
    }
}
