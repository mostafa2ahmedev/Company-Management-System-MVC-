using AutoMapper;
using El_sheikh.MVC.BLL.Models.Departments;
using El_sheikh.MVC.BLL.Services.Departments;
using El_sheikh.MVC.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Policy;

namespace El_sheikh.MVC.PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService ,ILogger<DepartmentController> logger,IWebHostEnvironment webHostEnvironment,IMapper mapper)
        {
            _departmentService = departmentService;
            this._logger = logger;
            this._webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        #region Index
        [HttpGet] //baseURL/ControllerName/Index
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();

            return View(departments);
        }

        #endregion




        #region Create

        [HttpGet] //baseURL/Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //baseURL/Departments/Create
        [ValidateAntiForgeryToken]  // Action filter
       

        public async Task<IActionResult> Create(DepartmentViewModel department)
        {
            var message = string.Empty;
            if (!ModelState.IsValid)   // Server side validation
            {
                return View(department);
            }

            try
            {
                var CreatedDepartment = _mapper.Map<DepartmentViewModel, CreatedDepartmentDto>(department);

         

                var created =await _departmentService.CreateDepartmentAsync(CreatedDepartment) > 0;

                if (!created)
                {
                    message = "Department is not created";
                    ModelState.AddModelError(string.Empty, message);


                    return View(department);
                }
          

            }
            catch (Exception ex)
            {
                // 1.Log Exception
                _logger.LogError(ex, ex.Message);
                // 2. Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An error has occured during Creating the department";
                TempData["Message"] = message;
              
            }

            TempData["Message"] = "Department Created Successfully";
            return RedirectToAction(nameof(Index)); // Fix: Redirect to Index action
        }

        #endregion




        #region Details 

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            if (id is null)
            {
                return BadRequest(); // built in view
            }
            var department =await _departmentService.GetDepartmentByIdAsync(id.Value);

            if (department is null)
            {
                return NotFound();// built in view
            }

            return View(department);

        }



        #endregion



    


        #region Update

        
        [HttpGet]//baseURL/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {


            if (id is null)
            {
                return BadRequest(); //Status code 400
            }
            var department =await _departmentService.GetDepartmentByIdAsync(id.Value);

            if (department is null)
            {
                return NotFound();
            }


            var departmentVM = _mapper.Map<DepartmentDetailsDto, DepartmentViewModel>(department);
            return View(departmentVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, DepartmentViewModel departmentEditVM)
        {
            if (!ModelState.IsValid)
            {  // Server side validation
                return View(departmentEditVM);

            }
            var message = string.Empty;
            try
            {
                var updatedDepartment = _mapper.Map<DepartmentViewModel, UpdatedDepartmentDto>(departmentEditVM);

                #region (updated) by me
                updatedDepartment.Id = id; 
                #endregion

                var updated =await _departmentService.UpdateDepartmentAsync(updatedDepartment) > 0;
                
                if (updated)
                    return RedirectToAction(nameof(Index));

                message = "An error has occured during updating the department :(";


            }
            catch (Exception ex)
            {
                // 1.Log Exception
                _logger.LogError(ex, ex.Message);
                // 2. Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An error has occured during updating the department";


            }
            ModelState.AddModelError(string.Empty, message);
            return View(departmentEditVM);

        }

        #endregion


        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department =await _departmentService.GetDepartmentByIdAsync(id.Value);

            if (department is null)
            {
                return NotFound();
            }
            return View(department);



        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var message = string.Empty;
            try
            {
                var deleted =await _departmentService.DeleteDepartmentAsync(id.Value);
                if (deleted)
                {
                    return RedirectToAction(nameof(Index));
                }

                message = "An error occurred while deleting the department";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _webHostEnvironment.IsDevelopment()
                    ? ex.Message
                    : "An error occurred while deleting the department";
            }

            ModelState.AddModelError(string.Empty, message);
            return View(_departmentService.GetDepartmentByIdAsync(id.Value));
        }
        #endregion

    }

    }


   
    

