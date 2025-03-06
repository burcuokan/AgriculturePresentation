using DataAccessLayer.Abstract;
using DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Delete(T t)
        {
            using (var c = new AgricultureContext())
            {
                c.Remove(t);
                c.SaveChanges();
            }
        }

        public T GetById(int id)
        {
            using (var c = new AgricultureContext())
            {
                return c.Set<T>().Find(id);
            }
        }

        public List<T> GetListAll()
        {
            using (var c = new AgricultureContext())
            {
                return c.Set<T>().ToList();
            }
        }

        public void Insert(T t)
        {
            using (var c = new AgricultureContext())
            {
                c.Add(t);
                c.SaveChanges();
            }
        }

        public void Update(T t)
        {
            using (var c = new AgricultureContext())
            {
                c.Update(t);
                c.SaveChanges();
            }
        }
    }
}
