using Domain.Common;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class RankingService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository;
    public List<Ranking> GetByUser(int userID)
    {
        _repository.Ran
    }
    public bool Update(int userID, Ranking ranking)
    {
        throw new NotImplementedException();
    }
}
