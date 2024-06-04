using Domain.Admin;
using Domain.Common;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeRepository<T> : IRepository<T> where T : Base
    {
        private static int nextID = 1;
        private readonly List<T> entities = [];

        public int Add(T entity)
        {
            entity.ID = nextID++;
            entities.Add(entity);
            return entity.ID;
        }

        public bool Delete(T entity)
        {
            return entities.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return entities;
        }

        public T? GetByID(int id)
        {
            return entities.FirstOrDefault(e => e.ID == id);
        }

        public bool Update(T entity)
        {
            int index = entities.FindIndex(e => e.ID == entity.ID);
            if (index != -1)
            {
                entities.RemoveAt(index);
                entities.Add(entity);
                return true;
            }
            return false;
        }
    }
}
