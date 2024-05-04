using Domain.Common;
using Domain.User;
using Infrastructure.DataRepositories;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class RankingService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository;
    public PersonalRanking? GetByUser(int userID)
    {
       return _repository.PersonalRankingRepository.GetByUser(userID);       
    }

    public Ranking? GetByCategory(string category)
    {
        return _repository.RankingRepository.GetByCategory(category);
    }
    public bool Update(int userID, Ranking ranking)
    {
        throw new NotImplementedException();
    }
}
