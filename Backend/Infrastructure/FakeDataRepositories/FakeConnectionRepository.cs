using Domain.Common;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeConnectionRepository : IConnectionRepository
    {
        private readonly List<Connection> Connections = [];

        public IEnumerable<Connection> GetAll()
        {
            return Connections;
        }

        public Connection? GetByID(int id)
        {
            return Connections.FirstOrDefault(a => a.ID == id);
        }

        public bool Add(Connection Connection)
        {
            Connections.Add(Connection);
            return true;
        }

        public bool Update(Connection Connection)
        {
            int index = Connections.FindIndex(u => u.ID == Connection.ID);
            if (index != -1)
            {
                Connections.RemoveAt(index);
                Connections.Add(Connection);
                return true;
            }
            return false;
        }

        public bool Delete(Connection Connection)
        {
            return Connections.Remove(Connection);
        }
    }
}
