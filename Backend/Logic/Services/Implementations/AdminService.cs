using Domain.Admin;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class AdminService(IDataRepository repository) : IAdminService
{
    private readonly IDataRepository _repository = repository;
    public bool CreateAdminAccount(Admin? admin)
    {
        if (admin == null) return false;
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
    public bool AuthoriseAdmin(int adminID,string token)
    {
        return Server.CreateAdminSession(adminID, token) is not null;
    }
    public bool GiveAdminPermissions(Admin admin)
    {
        admin.Accepted = true;
        return _repository.AdminRepository.Update(admin);
    }
}
