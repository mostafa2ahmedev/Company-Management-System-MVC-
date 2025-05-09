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
        int Add(T entity);

        int Update(T entity);

        int Delete(T entity);


    }
}
