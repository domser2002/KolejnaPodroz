using Domain.User;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class UserService(IDataRepository repository) : IUserService
{
    private readonly IDataRepository _repository = repository;
    public bool CreateUserAccount(User user)
    {
        _repository.UserRepository.Add(user);
        return true;
    }
    public bool RemoveUserAccount(int userID)
    {
        User? user = _repository.UserRepository.GetByID(userID);
        if (user == null) return false;
        _repository.UserRepository.Delete(user);
        return true;
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
        return _repository.UserRepository.GetByID(userID);
    }
}
