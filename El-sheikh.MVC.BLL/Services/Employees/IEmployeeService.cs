using El_sheikh.MVC.BLL.Models.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace El_sheikh.MVC.BLL.Services.Employees
{
    public interface IEmployeeService
    {

        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(string search);
        Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(CreatedEmployeeDto employeeDto);
        Task<int> UpdateEmployeeAsync(UpdatedEmployeeDto employeeDto);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
