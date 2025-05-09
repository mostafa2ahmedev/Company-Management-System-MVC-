using El_sheikh.MVC.DAL.Entities;
using El_sheikh.MVC.DAL.Entities.Employees;
using El_sheikh.MVC.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.Persistence.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase 
    {
        private protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        public IEnumerable<T> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
                return _dbContext.Set<T>().Where(X => !X.IsDeleted).AsNoTracking().ToList();
            else
                return _dbContext.Set<T>().Where(X => !X.IsDeleted).ToList();
        }

        public IQueryable<T> GetIQueryable()
        {
          return  _dbContext.Set<T>();
        }

        public T? Get(int id)
        {
          return   _dbContext.Set<T>().Find(id);
       
        }


        public int Add(T entity)
        {
           _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            entity.IsDeleted = true;
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }

       
    }
}

