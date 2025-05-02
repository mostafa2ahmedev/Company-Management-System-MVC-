using El_sheikh.MVC.DAL.Entities.Employee;
using El_sheikh.MVC.DAL.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.Persistence.Repositories.Employees
{
    public interface IEmployeeRepository
    {

        Employee? Get(int id);

        IEnumerable<Employee> GetAll(bool withAsNoTracking = true);

        IQueryable<Employee> GetAllAsQueryable();

        int Add(Employee employee);

        int Update(Employee employee);

        int Delete(Employee employee);

               
        
        
    }
}
