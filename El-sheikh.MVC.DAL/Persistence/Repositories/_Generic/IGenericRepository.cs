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
        //To enable idea of multitasking
        //Async operation
        Task<T?> GetAsync(int id);

        Task<IEnumerable<T>> GetAllAsync(bool withAsNoTracking = true);

        IQueryable<T> GetIQueryable();

        //Async Add use in specific scenario only
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
