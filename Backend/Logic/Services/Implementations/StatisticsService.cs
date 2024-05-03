using Domain.Common;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class StatisticsService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository;
    public List<Statistics> GetByUser(int userID)
    {
        throw new NotImplementedException();
    }
    public bool Update(int userID, Statistics statistics)
    {
        throw new NotImplementedException();
    }
}
