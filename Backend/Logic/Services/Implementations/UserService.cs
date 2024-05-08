using Domain.Admin;
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
        User? user = _repository.UserRepository.GetByID(userID);
        if (user is null) return false;
        user.Verified = true;
        return _repository.UserRepository.Update(user);
    }
    public User? AuthoriseUser(string firebaseID, string token)
    {
        int userID;
        User? user = _repository.UserRepository.GetAll().Where(u => u.FirebaseID == firebaseID).FirstOrDefault();
        if (user is null) return null;
        userID = user.ID;
        Server.CreateUserSession(userID, token);
        return user;
    }
    public User? GetUserByID(int userID)
    {
        return _repository.UserRepository.GetByID(userID);
    }
}
