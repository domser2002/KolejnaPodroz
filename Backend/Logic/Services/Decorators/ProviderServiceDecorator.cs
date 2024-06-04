using Domain.Common;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using System;

namespace Logic.Services.Decorators
{
    public class ProviderServiceDecorator : IProviderService
    {
        private readonly IProviderService _innerProviderService;
        private readonly IAdminService _adminService;

        public ProviderServiceDecorator(IProviderService innerProviderService, IAdminService adminService)
        {
            _innerProviderService = innerProviderService ?? throw new ArgumentNullException(nameof(innerProviderService));
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        public int AddProvider(Provider provider)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerProviderService.AddProvider(provider);
        }

        public bool RemoveProvider(int providerID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerProviderService.RemoveProvider(providerID);
        }

        public bool EditProvider(Provider newProvider)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerProviderService.EditProvider(newProvider);
        }

        public Provider GetProviderByID(int id)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerProviderService.GetProviderByID(id);
        }

        private bool CheckCondition()
        {
            return !_adminService.IsTechnicalBreak();
        }
    }
}
