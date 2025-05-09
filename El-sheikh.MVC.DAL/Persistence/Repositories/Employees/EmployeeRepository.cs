using El_sheikh.MVC.DAL.Entities.Employees;
using El_sheikh.MVC.DAL.Persistence.Data;
using El_sheikh.MVC.DAL.Persistence.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.Persistence.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) 
            : base(dbContext) //Ask CLR For Object from ApplicationDbContext
        {
        }
    }
}
 