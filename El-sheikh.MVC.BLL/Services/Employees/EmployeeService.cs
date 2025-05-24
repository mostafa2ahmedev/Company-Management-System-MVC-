using El_sheikh.MVC.BLL.Common.Services.Attachments;
using El_sheikh.MVC.BLL.Models.Employees;
using El_sheikh.MVC.DAL.Entities.Employees;
using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using El_sheikh.MVC.DAL.Persistence.Repositories.Employees;
using El_sheikh.MVC.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
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
        private readonly IAttachmentService _attachmentService;

        public EmployeeService(IUnitOfWork unitOfWork ,IAttachmentService attachmentService) //Ask CLR for creating object from class implement IUnitOfWork
        {
            _unitOfWork = unitOfWork;
            _attachmentService = attachmentService;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string search)
        {
            return await _unitOfWork.EmployeeRepository.GetIQueryable()
                .Where(E => !E.IsDeleted && (string.IsNullOrEmpty(search) || E.Name.ToLower().Contains(search.ToLower())))
                .Select(E => new EmployeeDto()
                {
                    Id = E.Id,
                    Name = E.Name,
                    Age = E.Age,
                    Email = E.Email,
                    Salary = E.Salary,
                    IsActive = E.IsActive,
                    Gender = E.Gender.ToString(),
                    EmployeeType = E.EmployeeType.ToString(),
                    Department = E.Department.Name
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetAsync(id);

            if (employee == null)
                return null;

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
                DepartmentId = employee.DepartmentId,
                Image = employee.Image
            };
        }

        public async Task<int> CreateEmployeeAsync(CreatedEmployeeDto employeeDto)
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

            if (employeeDto.Image is not null)
            {
                employee.Image = await _attachmentService.UploadAsync(employeeDto.Image, "images");
            }

             _unitOfWork.EmployeeRepository.Add(employee);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> UpdateEmployeeAsync(UpdatedEmployeeDto employeeDto)
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

            if (employeeDto.Image is not null)
            {
                employee.Image = await _attachmentService.UploadAsync(employeeDto.Image, "images");
            }

            _unitOfWork.EmployeeRepository.Update(employee);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetAsync(id);

            if (employee is null)
                return false;

            _unitOfWork.EmployeeRepository.Delete(employee);
            return await _unitOfWork.CompleteAsync() > 0;
        }


    }
}
