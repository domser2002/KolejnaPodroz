using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository : IRepository<User> { }
}
