using Domain.Admin;
using Domain.Common;
using Domain.User;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Logic.Services.Implementations;

public class AdminService(IDataRepository repository) : IAdminService
{
    private readonly IDataRepository _repository = repository;
    private bool isTechnicalBreak = false;
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
        Admin? admin = _repository.AdminRepository.GetAll().Where(a => a.FirebaseID == firebaseID && a.Accepted==true).FirstOrDefault();
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
    public List<User> GetAllUsers()
    {
        return _repository.UserRepository.GetAll().ToList();
        
    }

    public List<Admin> GetAllAdmins()
    {
        return _repository.AdminRepository.GetAll().ToList();
    }

    public List<Provider> GetAllProviders()
    {
        return _repository.ProviderRepository.GetAll().ToList();
    }

    public Admin? GetAdminByID(int adminID)
    {
        return _repository.AdminRepository.GetByID(adminID);
    }
    public User? GetUserByID(int userID)
    {
        return _repository.UserRepository.GetByID(userID);
    }
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

    public bool StartTechnicalBreak()
    {
        if(isTechnicalBreak)
        {
            return false;
        }
        else
        {
            isTechnicalBreak = true;
            return true;
        }
    }

    public bool StopTechnicalBreak() 
    {
        if(isTechnicalBreak ) 
        {
            isTechnicalBreak = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsTechnicalBreak()
    {
        return isTechnicalBreak;
    }

}
