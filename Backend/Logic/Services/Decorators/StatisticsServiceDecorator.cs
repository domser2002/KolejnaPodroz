using Domain.Common;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using System;

namespace Logic.Services.Decorators
{
    public class StatisticsServiceDecorator : IStatisticsService
    {
        private readonly IStatisticsService _innerStatisticsService;
        private readonly IAdminService _adminService;

        public StatisticsServiceDecorator(IStatisticsService innerStatisticsService, IAdminService adminService)
        {
            _innerStatisticsService = innerStatisticsService ?? throw new ArgumentNullException(nameof(innerStatisticsService));
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        public List<Statistics> GetByUser(int userID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerStatisticsService.GetByUser(userID);
        }

        public List<Statistics> GetByCategory(int categoryID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerStatisticsService.GetByCategory(categoryID);
        }

        public bool Update(Statistics statistics)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerStatisticsService.Update(statistics);
        }

        private bool CheckCondition()
        {
            return !_adminService.IsTechnicalBreak();
        }
    }
}
