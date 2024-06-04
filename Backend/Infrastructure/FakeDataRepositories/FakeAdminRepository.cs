using Domain.Admin;
using Domain.User;
using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeAdminRepository : FakeRepository<Admin>, IAdminRepository
    {
    }
}
