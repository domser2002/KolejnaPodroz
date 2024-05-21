using Domain.Admin;
using Domain.User;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Logic.Services.Implementations;

public class AdminService(IDataRepository repository) : IAdminService
{
    private readonly IDataRepository _repository = repository;
    public int CreateAdminAccount(Admin? admin)
    {
        if (admin == null) return -1;
        return _repository.AdminRepository.Add(admin);
    }
    public bool RemoveAdminAccount(int adminID)
    {
        Admin? admin = _repository.AdminRepository.GetByID(adminID);
        if (admin is null) return false;
        return _repository.AdminRepository.Delete(admin);
    }
    public bool VerifyAdminAccount(int adminID)
    {
        Admin? admin = _repository.AdminRepository.GetByID(adminID);
        if(admin is null) return false;
        admin.Verified = true;
        return _repository.AdminRepository.Update(admin);
    }
    public bool AcceptNewAdmin(int adminID)
    {
        Admin? admin = _repository.AdminRepository.GetByID(adminID);
        if (admin is null) return false;
        admin.Accepted = true;
        return _repository.AdminRepository.Update(admin);
    }
    public Admin? AuthoriseAdmin(string firebaseID,string token)
    {
        Admin? admin = _repository.AdminRepository.GetAll().Where(a => a.FirebaseID == firebaseID).FirstOrDefault();
        if(admin is null) return null;
        Server.CreateAdminSession(admin.ID, token);
        return admin;
    }
    public bool GiveAdminPermissions(Admin admin)
    {
        admin.Accepted = true;
        return _repository.AdminRepository.Update(admin);
    }

    public bool RemoveUserByID(int userID)
    {
        User? user = _repository.UserRepository.GetByID(userID);
        if (user is null) return false;
        return _repository.UserRepository.Delete(user);
    }
    public List<User>? GetAllUsers()
    {
        List<User> users = new List<User>(_repository.UserRepository.GetAll().ToList());
        if (users.Count == 0) return null;
        return users;
    }
<<<<<<< HEAD

    public User? GetUserByID(int userID)
    {
        return _repository.UserRepository.GetByID(userID);
    }   
=======
    public User? GetUserByID(int userID)
    {
        return _repository.UserRepository.GetByID(userID);
    }
>>>>>>> 6feade2 (Add editing user by admin)
    public bool EditUser(EditUser editedUser)
    {
        User? user = _repository.UserRepository.GetByID(editedUser.Id);
        if (user == null) return false;

        if (!string.IsNullOrEmpty(editedUser.FirebaseID))
        {
            user.FirebaseID = editedUser.FirebaseID;
        }

        if (editedUser.BirthDate.HasValue)
        {
            user.BirthDate = editedUser.BirthDate;
        }

        if (editedUser.PreferedSeatType != 0) // Assuming 0 is not a valid value for PreferedSeatType
        {
            user.PreferedSeatType = editedUser.PreferedSeatType;
        }

        if (editedUser.PreferedSeatLocation != 0) // Assuming 0 is not a valid value for PreferedSeatLocation
        {
            user.PreferedSeatLocation = editedUser.PreferedSeatLocation;
        }

        if (!string.IsNullOrEmpty(editedUser.FirstName))
        {
            user.FirstName = editedUser.FirstName;
        }

        if (!string.IsNullOrEmpty(editedUser.LastName))
        {
            user.LastName = editedUser.LastName;
        }

        if (!string.IsNullOrEmpty(editedUser.Email) && new EmailAddressAttribute().IsValid(editedUser.Email))
        {
            user.Email = editedUser.Email;
        }

        return _repository.UserRepository.Update(user);
    }
}
