using El_sheikh.MVC.DAL.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.Persistence.Repositories.Departments
{
    public interface IDepartmentRepository
    {



        IEnumerable<Department> GetAll(bool withAsNoTracking=true);
        IQueryable<Department> GetAllAsQueryable();
        Department? Get(int id);

        int Add(Department entity);

        int Update(Department entity);  

        int Delete(Department entity);  
    }
}
