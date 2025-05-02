using El_sheikh.MVC.DAL.Entities.Department;
using El_sheikh.MVC.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace El_sheikh.MVC.DAL.Persistence.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext) { //Ask CLR FOR Object from ApplicationDbContext Implicitly
            _dbContext = dbContext;
        }


        public IEnumerable<Department> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
               return _dbContext.Departments.AsNoTracking().ToList();

            return _dbContext.Departments.ToList();

        }

        public IQueryable<Department> GetAllAsQueryable() {

            return _dbContext.Departments;
        }
        public Department? Get(int id)
        {
            //var department = _dbContext.Departments.Local.FirstOrDefault(D => D.Id == id);

            //if (department is null)
            //{
            //    department = _dbContext.Departments.FirstOrDefault(D => D.Id == id);
            //}
            var department = _dbContext.Departments.Find(id);
            return department;
        }
        public int Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }


 
    }
}
