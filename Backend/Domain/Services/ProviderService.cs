using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public enum EditProviderOption
    {
        Add, Edit, Remove
    }
    public static class ProviderService
    {
        public static bool AddProvider(Provider provider)
        {
            if(provider is null)
            {
                return false;
            }

            if(!DatabaseService.InsertProvider(provider))
            {
                return false;
            }

            return true;
        }
        public static bool RemoveProvider(int providerID) 
        {
            if(!DatabaseService.RemoveProvider(providerID))
            {
                return false;
            }

            return true;
        }
        public static void EditProvider(int providerID, EditProviderOption option)
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

        private static void EditAddProvider()
        {
            Provider provider = new Provider();
            FillForm(provider);
            AddProvider(provider);
        }

        private static void EditEditProvider(int providerId)
        {
            Provider provider = GetProviderById(providerId);
            FillForm(provider);
            DatabaseService.UpdateProvider(providerId, provider);
        }

        private static void EditRemoveProvider(int providerId)
        {
            RemoveProvider(providerId);
        }

        private static void FillForm(Provider provider)
        {
            throw new NotImplementedException();
        }

        public static Provider GetProviderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
