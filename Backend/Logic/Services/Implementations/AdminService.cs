using Domain.Admin;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class AdminService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository;
    public bool CreateAdminAccount(Admin admin)
    {
        throw new NotImplementedException();
    }
    public bool RemoveAdminAccount(int adminID)
    {
        throw new NotImplementedException();
    }
    public bool VerifyAdminAccount(int adminID)
    {
        throw new NotImplementedException();
    }
    public bool AuthoriseAdmin(int adminID)
    {
        throw new NotImplementedException();
    }
    public void GiveAdminPermissions(Admin admin)
    {
        throw new NotImplementedException();
    }
}
