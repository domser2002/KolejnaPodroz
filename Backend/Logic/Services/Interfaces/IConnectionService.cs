using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IConnectionService
    {
        public bool AddConnection(Connection connection);
        public bool RemoveConnection(int connectionID);
        public void EditConnection(int connectionID);
        public Connection? GetConnectionByID(int connectionID);
    }
}
