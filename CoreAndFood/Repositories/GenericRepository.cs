using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreAndFood.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context c = new Context();

        public List<T> List()
        {
            return c.Set<T>().ToList();
        }
        public void Add(T g)
        {
            c.Set<T>().Add(g);
            c.SaveChanges();
        }
        public void Delete(T g)
        {
            c.Set<T>().Remove(g);
            c.SaveChanges();
        }
        public void Update(T g)
        {
            c.Set<T>().Update(g);
            c.SaveChanges();
        }
        public T Get(int id)
        {
            return c.Set<T>().Find(id);
        }
        public List<T> List(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
        public List<T> List(Expression<Func<T,bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }
    }
}
