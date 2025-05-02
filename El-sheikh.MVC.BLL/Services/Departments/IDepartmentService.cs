using El_sheikh.MVC.BLL.Models.Departments;

namespace El_sheikh.MVC.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetAllDepartments();

        DepartmentDetailsDto? GetDepartmentById(int id);

        int CreateDepartment(CreatedDepartmentDto departmentDto);

        int UpdateDepartment(UpdatedDepartmentDto departmentDto);

        bool DeleteDepartment(int id);

    }
}
