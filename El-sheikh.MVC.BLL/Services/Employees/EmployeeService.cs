using El_sheikh.MVC.BLL.Models.Employees;
using El_sheikh.MVC.DAL.Entities.Employees;
using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using El_sheikh.MVC.DAL.Persistence.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) //Ask clr
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetEmployees(string search)
        {
          return  _employeeRepository.GetIQueryable()
                .Where(E=>!E.IsDeleted).Select(E=> new EmployeeDto() { 
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
         var employee=  _employeeRepository.Get(id);

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
            return _employeeRepository.Add(employee);
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
           return _employeeRepository.Update(employee);
        }
        public bool DeleteEmployee(int id)
        {
            var employee= _employeeRepository.Get(id);

            if(employee is { })
                return _employeeRepository.Delete(employee) >0;
            return false;
        }



    }
}
