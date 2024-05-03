using Domain.Common;
using Domain.User;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        private readonly List<Discount> Discounts = [];

        public IEnumerable<Discount> GetAll()
        {
            return Discounts;
        }

        public Discount? GetByID(int id)
        {
            return Discounts.FirstOrDefault(a => a.ID == id);
        }

        public bool Add(Discount Discount)
        {
            Discounts.Add(Discount);
            return true;
        }

        public bool Update(Discount Discount)
        {
            int index = Discounts.FindIndex(u => u.ID == Discount.ID);
            if (index != -1)
            {
                Discounts.RemoveAt(index);
                Discounts.Add(Discount);
                return true;
            }
            return false;
        }

        public bool Delete(Discount Discount)
        {
            return Discounts.Remove(Discount);
        }
    }
}
