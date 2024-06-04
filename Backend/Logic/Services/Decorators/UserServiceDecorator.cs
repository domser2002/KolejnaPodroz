using Domain.User;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using System;

namespace Logic.Services.Decorators
{
    public class UserServiceDecorator : IUserService
    {
        private readonly IUserService _innerUserService;
        private readonly IAdminService _adminService;

        public UserServiceDecorator(IUserService innerUserService, IAdminService adminService)
        {
            _innerUserService = innerUserService ?? throw new ArgumentNullException(nameof(innerUserService));
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        public int CreateUserAccount(User user)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerUserService.CreateUserAccount(user);
        }

        public bool RemoveUserAccount(int userID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerUserService.RemoveUserAccount(userID);
        }

        public bool VerifyUserAccount(int userID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerUserService.VerifyUserAccount(userID);
        }

        public User AuthoriseUser(string firebaseID, string token)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerUserService.AuthoriseUser(firebaseID, token);
        }

        public User GetUserByID(int userID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerUserService.GetUserByID(userID);
        }

        private bool CheckCondition()
        {
            return !_adminService.IsTechnicalBreak();
        }
    }
}
