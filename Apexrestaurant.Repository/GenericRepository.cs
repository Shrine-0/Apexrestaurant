using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Apexrestaurant.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected RestaurantContext DbContext { get; set; }
        public T Get(int id)
        {
            return DbContext.Find<T>(id);
        }
        public IQueryable<T> Query()
        {
            return DbContext.Set<T>().AsQueryable();
        }
        public void Insert(T entity)
        {
            DbContext.Set<T>().Add(entity);
            DbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            DbContext.SaveChanges();
        }
    }
}