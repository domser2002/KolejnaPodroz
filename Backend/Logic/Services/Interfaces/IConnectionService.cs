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
        public int AddConnection(Connection connection);
        public bool RemoveConnection(int connectionID);
        public bool EditConnection(Connection newConnection);
        public Connection? GetConnectionByID(int connectionID);

        // returns list of all connections from origin to destination
        // and where train departures from origin in the same day as when
        public List<Connection> SearchConnections(string from, string to, DateTime when);
    }
}
