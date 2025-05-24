using El_sheikh.MVC.BLL.Models.Departments;
using El_sheikh.MVC.BLL.Services.Departments;
using El_sheikh.MVC.DAL.Entities.Departments;
using El_sheikh.MVC.DAL.Persistence.Repositories.Departments;
using El_sheikh.MVC.DAL.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork) // Ask CLR to create object from class implements IUnitOfWork
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetIQueryable().Where(D => !D.IsDeleted).Select(department => new DepartmentDTO()
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
            var department = _unitOfWork.DepartmentRepository.Get(id);

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
            _unitOfWork.DepartmentRepository.Add(createdDepartment);
            return _unitOfWork.Complete();
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
            _unitOfWork.DepartmentRepository.Update(updatedDepartment);
            return _unitOfWork.Complete();
        }

        public bool DeleteDepartment(int id)
        {
            var deptRepo = _unitOfWork.DepartmentRepository;
        var department = deptRepo.Get(id);

            if (department is { })
                deptRepo.Delete(department);


            return _unitOfWork.Complete()>0;

  
        }

 
        
    }
}
