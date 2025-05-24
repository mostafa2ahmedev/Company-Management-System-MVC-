using El_sheikh.MVC.BLL.Models.Departments;

namespace El_sheikh.MVC.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();

        Task<DepartmentDetailsDto?> GetDepartmentByIdAsync(int id);

        Task<int> CreateDepartmentAsync(CreatedDepartmentDto departmentDto);

        Task<int> UpdateDepartmentAsync(UpdatedDepartmentDto departmentDto);

        Task<bool> DeleteDepartmentAsync(int id);

    }
}
