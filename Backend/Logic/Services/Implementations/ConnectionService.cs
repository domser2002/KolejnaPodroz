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

        public int AddConnection(Connection? connection)
        {
            if(connection is null) return -1;
            return _repository.ConnectionRepository.Add(connection);
        }

        public bool RemoveConnection(int connectionID) 
        {
            Connection? connection = _repository.ConnectionRepository.GetByID(connectionID);
            if (connection == null) return false;
            _repository.ConnectionRepository.Delete(connection);
            return true;
        }

        public bool EditConnection(Connection newConnection)
        {
            Connection? connection = _repository.ConnectionRepository.GetByID(newConnection.ID);
            if (connection == null) return false;
            return _repository.ConnectionRepository.Update(newConnection);
        }

        public Connection? GetConnectionByID(int connectionID)
        {
            return _repository.ConnectionRepository.GetByID(connectionID);
        }

        public List<Connection> SearchConnections(string from, string to, DateTime when)
        {
            List<Connection> connections = [];

            IEnumerable<Connection> col_connections = _repository.ConnectionRepository.GetAll();
            List<Station> stations = _repository.StationRepository.GetAll().ToList();
            List<StopDetails> stopDetails = _repository.StopDetailsRepository.GetAll().ToList();
            int idx_station_from = stations.FindIndex(s => s.Name == from);
            int idx_station_to = stations.FindIndex(s => s.Name == to);
            foreach (Connection col_connection in col_connections) 
            {
                List<StopDetails> connectionStopDetails = stopDetails.Where(sd => sd.ConnectionID == col_connection.ID).ToList();
                int idx_origin = connectionStopDetails.FindIndex(st => st.StationID == stations[idx_station_from].ID);
                int idx_destination = connectionStopDetails.FindIndex(st => st.StationID == stations[idx_station_to].ID);

                if(idx_origin < 0 || idx_destination < 0) continue;
                if(idx_origin >= idx_destination) continue;

                DateTime? originDepartureTime = connectionStopDetails[idx_origin].DepartureTime;
                if (originDepartureTime == null) continue;
                DateTime originDeparture = (DateTime)originDepartureTime;
                if (originDeparture.Year != when.Year ||
                    originDeparture.Month != when.Month ||
                    originDeparture.Day != when.Day) continue;

                connections.Add(col_connection);
            }

            return connections;
        }
    }
}
