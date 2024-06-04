using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IProviderService
    {
        public int AddProvider(Provider? provider);
        public bool RemoveProvider(int providerID);
        public bool EditProvider(Provider newProvider);       
        public Provider? GetProviderByID(int id);
    }
}
