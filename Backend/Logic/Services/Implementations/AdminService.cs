using Domain.Admin;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

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
}
