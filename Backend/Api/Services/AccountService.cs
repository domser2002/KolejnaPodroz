using Domain.Common;
using Domain.User;
using Microsoft.EntityFrameworkCore;



namespace Api.Services
{
    public class AccountService
    {

        DomainDBContext ddbContext = new DomainDBContext();
      
        public AccountInfo GetAccountInfo(int userID)
        {
           return ddbContext.AccountInfo.Find(userID);
        }
        public bool UpdateAccountInfo(int userID) 
        { 
            throw new NotImplementedException();
        }
        public CommonAccountInfo CheckUserAccount(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
