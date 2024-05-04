using System.ComponentModel.DataAnnotations;

namespace Domain.Admin
{
public class Admin : Base
{
    [Required]
    public Admin() { }
    public bool AddProvider(Provider provider)
    {
        throw new NotImplementedException();
    }
    public bool EditProvider()
    { 
        throw new NotImplementedException();
    }
    public bool RemoveProvider(int providerID) 
    {
        throw new NotImplementedException();
    }
    public List<Provider> ListProviders() 
    {
        throw new NotImplementedException();
    }
    public List<Complaint> ListComplaints() 
    {
        throw new NotImplementedException();
    }
    public void AnswerComplaint(Complaint complaint, string answer) 
    {
        throw new NotImplementedException();
    }
    public CommonAccountInfo? CheckUserAccount(int userID)
    { 
        throw new NotImplementedException();
    }
    public List<Admin> ListAdminCandidates()
    {
        throw new NotImplementedException();
    }
    public void AcceptNewAdmin(int adminID)
    {
        throw new NotImplementedException();
    }
    public void RejectNewAdmin(int adminID) 
    {
        throw new NotImplementedException();
    }
    public bool DeleteUser(int userID) 
    {
        throw new NotImplementedException();
    }
    public void BackupUserDB()
    {
        throw new NotImplementedException();
    }
    public void BackupProviderDB() 
    {
        throw new NotImplementedException();
    }
    public void BackupConnectionDB()
    {
        throw new NotImplementedException();
    }
}
}
