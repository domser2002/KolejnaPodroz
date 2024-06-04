using Infrastructure.Interfaces;
using Domain.Common;
using System;
using Logic.Services.Interfaces;

namespace Logic.Services.Decorators
{
    public class ConnectionServiceDecorator : IConnectionService
    {
        private readonly IConnectionService _innerConnectionService;
        private readonly IAdminService _adminService;

        public ConnectionServiceDecorator(IConnectionService innerConnectionService, IAdminService adminService)
        {
            _innerConnectionService = innerConnectionService ?? throw new ArgumentNullException(nameof(innerConnectionService));
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        public int AddConnection(Connection connection)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerConnectionService.AddConnection(connection);
        }

        public bool RemoveConnection(int connectionID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerConnectionService.RemoveConnection(connectionID);
        }

        public bool EditConnection(Connection newConnection)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerConnectionService.EditConnection(newConnection);
        }

        public Connection GetConnectionByID(int connectionID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerConnectionService.GetConnectionByID(connectionID);
        }

        public List<Connection> SearchConnections(string from, string to, DateTime when)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerConnectionService.SearchConnections(from, to, when);
        }

        private bool CheckCondition()
        {
            return !_adminService.IsTechnicalBreak();
        }
    }
}
