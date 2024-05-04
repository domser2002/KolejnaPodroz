using Domain.Common;
using Domain.User;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class DiscountRepository(DomainDBContext context) : IDiscountRepository
    {
        private readonly DomainDBContext _context = context;
        public bool Add(Discount Discount)
        {
            _context.Discount.Add(Discount);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(Discount Discount)
        {
            _context.Discount.Remove(Discount);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Discount> GetAll()
        {
            return [.. _context.Discount];
        }

        public Discount? GetByID(int id)
        {
            return _context.Discount.FirstOrDefault(a => a.ID == id);
        }

        public bool Update(Discount Discount)
        {
            _context.Discount.Update(Discount);
            return _context.SaveChanges() == 1;
        }
    }
}
