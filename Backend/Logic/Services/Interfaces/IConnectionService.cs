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
        public void EditConnection(int connectionID, Connection newConnection);
        public Connection? GetConnectionByID(int connectionID);

        // returns list of all connections from origin to destination
        // and where train departures from origin in interval <from, to>
        public List<Connection> SearchConnections(string origin, string destination, DateTime from, DateTime to);
    }
}
