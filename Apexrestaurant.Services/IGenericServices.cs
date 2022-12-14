using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Apexrestaurant.Services
{
    public interface IGenericServices<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}