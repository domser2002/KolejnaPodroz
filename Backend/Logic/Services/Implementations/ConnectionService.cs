using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Logic.Services.Implementations
{
    public class ConnectionService(IDataRepository repository) : Interfaces.IConnectionService
    {
        private readonly IDataRepository _repository = repository;

        public bool AddConnection(Connection? connection)
        {
            if(connection is null) return false;
            _repository.ConnectionRepository.Add(connection);
            return true;
        }

        public bool RemoveConnection(int connectionID) 
        {
            Connection? connection = _repository.ConnectionRepository.GetByID(connectionID);
            if (connection == null) return false;
            _repository.ConnectionRepository.Delete(connection);
            return true;
        }

        public void EditConnection(int connectionID)
        {
            Connection? connection = _repository.ConnectionRepository.GetByID(connectionID);
            if (connection == null) return;
            _repository.ConnectionRepository.Delete(connection);
            _repository.ConnectionRepository.Add(connection);
        }

        public Connection? GetConnectionByID(int connectionID)
        {
            return _repository.ConnectionRepository.GetByID(connectionID);
        }

        public List<Connection> SearchConnections(string origin, string destination, DateTime from, DateTime to)
        {
            List<Connection> connections = new List<Connection>();

            IEnumerable<Connection> col_connections = _repository.ConnectionRepository.GetAll();
            foreach (Connection col_connection in col_connections) 
            {
                int idx_origin = col_connection.Stations.IndexOf(origin);
                int idx_destination = col_connection.Stations.IndexOf(destination);

                if(idx_origin < 0 || idx_destination < 0) continue;
                if(idx_origin >= idx_destination) continue;

                DateTime originDepartureTime = col_connection.DepartureTimes[idx_origin];

                if(originDepartureTime < from || originDepartureTime > to) continue;

                connections.Add(col_connection);
            }

            return connections;
        }
    }
}
