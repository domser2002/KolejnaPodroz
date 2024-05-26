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
    public class StopDetailsRepository(DomainDBContext context) : Repository<StopDetails>(context), IStopDetailsRepository
    {
    }
}
