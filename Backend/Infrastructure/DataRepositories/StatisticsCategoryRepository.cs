using Domain.Common;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class StatisticsCategoryRepository(DomainDBContext context) : Repository<StatisticCategory>(context), IStatisticsCategoryRepository
    {
    }
}
