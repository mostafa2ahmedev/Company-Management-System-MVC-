using El_sheikh.MVC.DAL.Entities.Employee;
using El_sheikh.MVC.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.Persistence.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
             return   _dbContext.Employees.AsNoTracking().ToList();
            else
             return   _dbContext.Employees.ToList();
        }

        public IQueryable<Employee> GetAllAsQueryable()
        {
            throw new NotImplementedException();
        }


        public Employee? Get(int id)
        {
            throw new NotImplementedException();
        }


        public int Add(Employee employee)
        {
            throw new NotImplementedException();
        }
        public int Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int Delete(Employee employee)
        {
            throw new NotImplementedException();
        }


      

   
    }
}
