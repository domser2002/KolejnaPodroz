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

        public bool AddConnection(Connection connection)
        {
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
    }
}
