using El_sheikh.MVC.DAL.Entities;
using El_sheikh.MVC.DAL.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.Persistence.Repositories._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        T? Get(int id);

        IEnumerable<T>GetAll(bool withAsNoTracking = true);

        IQueryable<T> GetIQueryable();
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
