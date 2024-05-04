using Domain.User;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class UserService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository;
    public bool CreateUserAccount(User user)
    {
        throw new NotImplementedException();
    }
    public bool RemoveUserAccount(int userID)
    {
        throw new NotImplementedException();
    }
    public bool VerifyUserAccount(int userID)
    {
        throw new NotImplementedException();
    }
    public bool AuthoriseUser(int userID)
    {
        throw new NotImplementedException();
    }
    public User GetUserByID(int userID)
    {
        throw new NotImplementedException();
    }
}
