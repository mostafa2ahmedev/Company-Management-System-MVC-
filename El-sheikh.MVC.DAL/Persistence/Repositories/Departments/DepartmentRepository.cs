using El_sheikh.MVC.DAL.Entities.Departments;
using El_sheikh.MVC.DAL.Persistence.Data;
using El_sheikh.MVC.DAL.Persistence.Repositories._Generic;
using Microsoft.EntityFrameworkCore;

namespace El_sheikh.MVC.DAL.Persistence.Repositories.Departments
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext) //Ask CLR For Object from ApplicationDbContext
        {
        }
    }
}
