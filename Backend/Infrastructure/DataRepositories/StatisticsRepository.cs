using Domain.Admin;
using Domain.Common;
using Domain.User;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class StatisticsRepository(DomainDBContext context) : Repository<Statistics>(context), IStatisticsRepository
    {
    }
}
