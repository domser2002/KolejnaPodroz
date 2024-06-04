using Domain.Admin;
using Domain.Common;
using Domain.User;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeDiscountRepository : FakeRepository<Discount>, IDiscountRepository
    {
    }
}
