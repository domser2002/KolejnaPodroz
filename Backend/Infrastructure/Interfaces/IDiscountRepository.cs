using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDiscountRepository
    {
        public IEnumerable<Discount> GetAll();
        public Discount? GetByID(int id);
        public bool Add(Discount Discount);
        public bool Update(Discount Discount);
        public bool Delete(Discount Discount);
    }
}
