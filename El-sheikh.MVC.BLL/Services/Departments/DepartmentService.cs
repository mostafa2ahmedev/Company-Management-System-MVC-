using El_sheikh.MVC.BLL.Models.Departments;
using El_sheikh.MVC.BLL.Services.Departments;
using El_sheikh.MVC.DAL.Entities.Department;
using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_sheikh.MVC.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentService) // Ask CLR to create object from class implements IDepartmentRepository
        {
            _departmentRepository = departmentService;
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllAsQueryable().Select(department => new DepartmentDTO()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate
            }).AsNoTracking().ToList();


        return departments;
          
        }
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);

            if (department is { } ) {
                return new DepartmentDetailsDto()
                {
                    Id = department.Id,
                    Code= department.Code,
                    Name = department.Name,
                    Description = department.Description,
                    CreationDate = department.CreationDate,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn,
                 
                };
        
            }
            return null;
        }

        public int CreateDepartment(CreatedDepartmentDto departmentDto)
        {
            var createdDepartment = new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                CreatedBy = 1,
                CreatedOn = DateTime.UtcNow,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
                

            };
       return  _departmentRepository.Add(createdDepartment);
        }
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var updatedDepartment = new Department()
            {
                Id= departmentDto.Id,
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreationDate = departmentDto.CreationDate,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,         
       
            };
            return _departmentRepository.Update(updatedDepartment);
        }

        public bool DeleteDepartment(int id)
        {
        var department = _departmentRepository.Get(id);

            if (department is { })
              return  _departmentRepository.Delete(department) >0;


            return false;

  
        }

 
        
    }
}
