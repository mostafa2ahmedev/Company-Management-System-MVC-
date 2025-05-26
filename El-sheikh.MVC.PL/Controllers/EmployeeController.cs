using El_sheikh.MVC.BLL.Models.Employees;
using El_sheikh.MVC.BLL.Services.Departments;
using El_sheikh.MVC.BLL.Services.Employees;
using El_sheikh.MVC.DAL.Common.Enums;
using El_sheikh.MVC.DAL.Entities.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace El_sheikh.MVC.PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(IEmployeeService employeeService ,ILogger<EmployeeController> logger
            , IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _employeeService = employeeService;
  
        }

        #region Index
        [HttpGet]//baseURL/Employee/Index
        public async Task<IActionResult> Index(string search)
        {
            var employees =await _employeeService.GetEmployeesAsync(search);
            return View(employees);
        }



        #endregion


        #region Create

        [HttpGet]
        public IActionResult Create([FromServices] IDepartmentService _departmentService) {

            //ViewData["Departments"] = _departmentService.GetAllDepartments();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatedEmployeeDto employeeDto) {

            var message = string.Empty;
            if (!ModelState.IsValid)   // Server side validation
            {
                return View(employeeDto);
            }

            try
            {
                var created = await _employeeService.CreateEmployeeAsync(employeeDto) > 0;

                if (created)
                    return RedirectToAction(nameof(Index)); // Fix: Redirect to Index action


                message = "An error has occured during Creating the department :(";

            }
            catch (Exception ex)
            {
                // 1.Log Exception
                _logger.LogError(ex, ex.Message);
                // 2. Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An error has occured during Creating the department";

            }

            ModelState.AddModelError(string.Empty, message);
            return View(employeeDto);
        }


        #endregion

        #region Details
        [HttpGet]//baseUrl/Employee/Details
        public async Task<IActionResult> Details(int? id) {
            if (id is null) { 
            return BadRequest();
            }

             var employeeDetails=await  _employeeService.GetEmployeeByIdAsync(id.Value);

            if (employeeDetails is null)
            {
                return NotFound();

            }
          
               return View(employeeDetails);
        }



        #endregion


        #region Edit

        [HttpGet] //baseUrl/Employee/Edit/id
        public async Task<IActionResult> Edit(int? id) 
         {

            if (id is null) {
                return BadRequest();
            }
            var employee =await _employeeService.GetEmployeeByIdAsync(id.Value);

            if (employee is null) {

                return NotFound();
            }

            return View(new UpdatedEmployeeDto() {
            Name = employee.Name,
            Age = employee.Age,
            Email = employee.Email,
            Gender = (Gender) Enum.Parse(typeof(Gender), employee.Gender),
            EmployeeType = (EmployeeType)Enum.Parse(typeof(EmployeeType), employee.EmployeeType),
            IsActive = employee.IsActive,
            PhoneNumber = employee.PhoneNumber,
            Salary = employee.Salary,
            HiringDate = employee.HiringDate,
            Address = employee.Address,
            DepartmentId = employee.DepartmentId
            });
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id,UpdatedEmployeeDto employee)
        {

            if (!ModelState.IsValid) {
                return View(employee);
            }
            var message = string.Empty;
            try
            {
                var updated= await _employeeService.UpdateEmployeeAsync(employee)>0;
                if (updated)
                    return RedirectToAction(nameof(Index));


                message = "Employee is not updated";
            }
            catch (Exception ex)
            {

                // 1.Log Exception
                _logger.LogError(ex, ex.Message);
                // 2. Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An error has occured during updating the Employee";


            }
            ModelState.AddModelError(string.Empty, message);
            return View(employee);
        }
        #endregion


        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id) {
            if (id is null)
            {
                return BadRequest();
            }
            var message = string.Empty;
            try
            {


                var deleted = await  _employeeService.DeleteEmployeeAsync(id.Value);

                if (deleted)
                    return RedirectToAction(nameof(Index));

                message = "An error has occured during deleting the Employee";
            }
            catch (Exception ex)
            {

                // 1.Log Exception
                _logger.LogError(ex, ex.Message);
                // 2. Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An error has occured during deleting the Employee";


            }
            ModelState.AddModelError(string.Empty, message);
            return View();

        }
        #endregion
    }
}

