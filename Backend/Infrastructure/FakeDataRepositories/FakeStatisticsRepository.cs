using Domain.Admin;
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
    public class FakeStatisticsRepository : FakeRepository<Statistics>, IStatisticsRepository
    {
    }
}
