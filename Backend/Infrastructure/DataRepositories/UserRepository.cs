using Domain.Admin;
using Domain.Common;
using Domain.User;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class UserRepository(DomainDBContext context) : Repository<User>(context), IUserRepository
    {
    }
}
