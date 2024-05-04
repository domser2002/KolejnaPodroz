using Domain.Common;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class StatisticsService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository;
    public Statistics? GetByUser(int userID)
    {
        return _repository.StatisticsRepository.GetByUser(userID);
    }
    public bool Update(int userID, Statistics statistics)
    {
        throw new NotImplementedException();
    }
}
