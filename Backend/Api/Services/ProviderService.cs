using Domain.Common;

namespace Api.Services
{
    public enum EditProviderOption
    {
        Add, Edit, Remove
    }
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
        public void EditProvider(int providerID, EditProviderOption option)
        { 
            switch(option) 
            {
                case EditProviderOption.Add:
                    EditAddProvider();
                    break;
                case EditProviderOption.Edit:
                    EditEditProvider(providerID);
                    break;
                case EditProviderOption.Remove:
                    EditRemoveProvider(providerID);
                    break;
            }
        }

        private void EditAddProvider()
        {
            Provider provider = new Provider();
            FillForm(provider);
            AddProvider(provider);
        }

        private void EditEditProvider(int providerId)
        {
            Provider provider = GetProviderById(providerId);
            FillForm(provider);
            _databaseService.UpdateProvider(providerId, provider);
        }

        private void EditRemoveProvider(int providerId)
        {
            RemoveProvider(providerId);
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
