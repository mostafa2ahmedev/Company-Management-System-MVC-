using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using El_sheikh.MVC.DAL.Persistence.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.DAL.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IEmployeeRepository EmployeeRepository { get;  }
        public IDepartmentRepository DepartmentRepository { get; }


        Task<int> CompleteAsync();

    
    }
}
