using Domain.Common;
using Domain.User;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class StatisticsService(IDataRepository repository) : IStatisticsService
{
    private readonly IDataRepository _repository = repository;
    public List<Statistics>? GetByUser(int userID)
    {
        return _repository.StatisticsRepository.GetAll().Where(s => s.UserID == userID).ToList();
    }
    public List<Statistics>? GetByCategory(int categoryID) 
    {
        return _repository.StatisticsRepository.GetAll().Where(s => s.CategoryID == categoryID).ToList();
    }
    public bool Update(Statistics statistics)
    {
        return _repository.StatisticsRepository.Update(statistics);
    }
}
