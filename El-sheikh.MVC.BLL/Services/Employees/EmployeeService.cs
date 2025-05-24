using El_sheikh.MVC.BLL.Models.Employees;
using El_sheikh.MVC.DAL.Entities.Employees;
using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using El_sheikh.MVC.DAL.Persistence.Repositories.Employees;
using El_sheikh.MVC.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork) //Ask CLR for creating object from class implement IUnitOfWork
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EmployeeDto> GetEmployees(string search)
        {
          return  _unitOfWork.EmployeeRepository.GetIQueryable()
                .Where(E=>!E.IsDeleted && (string.IsNullOrEmpty(search)||E.Name.ToLower().Contains(search.ToLower())))
                .Select(E=> new EmployeeDto() { 
          Id = E.Id,
          Name = E.Name,
          Age = E.Age,
          Email = E.Email,
          Salary = E.Salary,
          IsActive = E.IsActive,
          Gender = E.Gender.ToString(),
          EmployeeType = E.EmployeeType.ToString(),
          Department =E.Department.Name
          });
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
         var employee= _unitOfWork.EmployeeRepository.Get(id);

            if (employee is { }) {
                return new EmployeeDetailsDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    IsActive = employee.IsActive,
                    Gender = employee.Gender.ToString(),
                    Address = employee.Address,
                    CreatedBy = employee.CreatedBy,
                    CreatedOn = employee.CreatedOn,
                    EmployeeType = employee.EmployeeType.ToString(),
                    IsDeleted = employee.IsDeleted,
                    LastModifiedBy = employee.LastModifiedBy,
                    LastModifiedOn = employee.LastModifiedOn,
                    DepartmentId =employee.DepartmentId

                };

            } else
                return null;
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Name = employeeDto.Name,
                Address = employeeDto.Address,
                Age = employeeDto.Age,           
                Email = employeeDto.Email,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                IsActive = employeeDto.IsActive,
                PhoneNumber = employeeDto.PhoneNumber,
                Salary = employeeDto.Salary,
                EmployeeType = employeeDto.EmployeeType,
                LastModifiedBy = 1,
                CreatedBy = 1,
                LastModifiedOn = DateTime.Now,
                DepartmentId = employeeDto.DepartmentId,
                
                

            };

            // Add
            // Update
            // Delete
             _unitOfWork.EmployeeRepository.Add(employee);
            return _unitOfWork.Complete();
        }
        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Address = employeeDto.Address,
                Age = employeeDto.Age,
                Email = employeeDto.Email,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                IsActive = employeeDto.IsActive,
                PhoneNumber = employeeDto.PhoneNumber,
                Salary = employeeDto.Salary,
                EmployeeType = employeeDto.EmployeeType,
                LastModifiedBy = 1,
                CreatedBy = 1,
                LastModifiedOn = DateTime.Now,
                DepartmentId = employeeDto.DepartmentId,

            };
            _unitOfWork.EmployeeRepository.Update(employee);
            return _unitOfWork.Complete();
        }
        public bool DeleteEmployee(int id)
        {
            var employeeRepo = _unitOfWork.EmployeeRepository;
            var employee= employeeRepo.Get(id);

            if(employee is { })
                 employeeRepo.Delete(employee);

            return _unitOfWork.Complete()>0;
        }



    }
}
