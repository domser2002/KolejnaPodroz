using Domain.Common;
using Infrastructure.DataRepositories;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Implementations
{
    public class StationService(IDataRepository repository) : IStationService
    {
        private IDataRepository _repository = repository;
        public Station? GetByID(int stationID)
        {
            return _repository.StationRepository.GetByID(stationID);
        }
    }
}
