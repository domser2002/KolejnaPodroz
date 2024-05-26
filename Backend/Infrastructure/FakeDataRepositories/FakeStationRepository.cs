using Domain.Common;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeStationRepository : FakeRepository<Station>, IStationRepository
    {
    }
}
