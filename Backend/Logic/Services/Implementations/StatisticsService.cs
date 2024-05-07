using Domain.Common;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class StatisticsService(IDataRepository repository) : IStatisticsService
{
    private readonly IDataRepository _repository = repository;
    public List<Statistics>? GetByUser(int userID)
    {
        return _repository.StatisticsRepository.GetByUser(userID);
    }
    public bool Update(Statistics statistics)
    {
        return _repository.StatisticsRepository.Update(statistics);
    }
}
