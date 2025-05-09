using El_sheikh.MVC.BLL.Models.Employees;

namespace El_sheikh.MVC.BLL.Services.Employees
{
    public interface IEmployeeService
    {

        IEnumerable<EmployeeDto> GetEmployees(string search);

        EmployeeDetailsDto? GetEmployeeById(int id);

        int CreateEmployee(CreatedEmployeeDto employeeDto);

        int UpdateEmployee(UpdatedEmployeeDto employeeDto);

        bool DeleteEmployee(int id);
    }
}
