﻿using Domain.Common;
using Domain.User;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeProviderRepository : IProviderRepository
    {
        private readonly List<Provider> Providers = [];

        public IEnumerable<Provider> GetAll()
        {
            return Providers;
        }

        public Provider? GetByID(int id)
        {
            return Providers.FirstOrDefault(a => a.ID == id);
        }

        public bool Add(Provider Provider)
        {
            Providers.Add(Provider);
            return true;
        }

        public bool Update(Provider Provider)
        {
            int index = Providers.FindIndex(u => u.ID == Provider.ID);
            if (index != -1)
            {
                Providers.RemoveAt(index);
                Providers.Add(Provider);
                return true;
            }
            return false;
        }

        public bool Delete(Provider Provider)
        {
            return Providers.Remove(Provider);
        }
    }
}