using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IProviderRepository
    {
        public IEnumerable<Provider> GetAll();
        public Provider? GetByID(int id);
        public int Add(Provider Provider);
        public bool Update(Provider Provider);
        public bool Delete(Provider Provider);
    }
}
