using El_sheikh.MVC.DAL.Persistence.Data;
using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using El_sheikh.MVC.DAL.Persistence.Repositories.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IEmployeeRepository EmployeeRepository {
            get 
            {
                return new EmployeeRepository(_dbContext); 
            } 
        }
        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_dbContext); 

   


        public UnitOfWork(ApplicationDbContext dbContext) // Ask CLR for creating object from class "Application Db Context"
        {
            _dbContext = dbContext;
        }
        public int Complete()
        {
        return  _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
