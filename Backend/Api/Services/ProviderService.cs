using Domain.Common;

namespace Api.Services
{
    public class ProviderService
    {
        private readonly DatabaseService _databaseService;
        public ProviderService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public bool AddProvider(Provider provider)
        {
            if(provider is null)
            {
                return false;
            }

            if(!_databaseService.InsertProvider(provider))
            {
                return false;
            }

            return true;
        }
        public bool RemoveProvider(int providerID) 
        {
            if(!_databaseService.RemoveProvider(providerID))
            {
                return false;
            }

            return true;
        }
        private void AddProvider()
        {
            Provider provider = new Provider();
            FillForm(provider);
            AddProvider(provider);
        }

        public bool EditProvider(int providerId, Provider newProvider)
        {
            Provider provider = GetProviderById(providerId);
            FillForm(provider);
            return _databaseService.UpdateProvider(providerId, provider);
        }
        private void FillForm(Provider provider)
        {
            throw new NotImplementedException();
        }

        public Provider GetProviderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
