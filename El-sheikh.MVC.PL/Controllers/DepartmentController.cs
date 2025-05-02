using El_sheikh.MVC.BLL.Models.Departments;
using El_sheikh.MVC.BLL.Services.Departments;
using El_sheikh.MVC.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Policy;

namespace El_sheikh.MVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DepartmentController(IDepartmentService departmentService ,ILogger<DepartmentController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _departmentService = departmentService;
            this._logger = logger;
            this._webHostEnvironment = webHostEnvironment;
        }

        #region Index
        [HttpGet] //baseURL/ControllerName/Index
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
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

        public IActionResult Create(CreatedDepartmentDto department)
        {
            var message = string.Empty;
            if (!ModelState.IsValid)   // Server side validation
            {
                return View(department);
            }

            try
            {
                var created = _departmentService.CreateDepartment(department) > 0;

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
            return View(department);
        }

        #endregion




        #region Details

        [HttpGet]
        public IActionResult Details(int? id)
        {

            if (id is null)
            {
                return BadRequest(); // built in view
            }
            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
            {
                return NotFound();// built in view
            }

            return View(department);

        }



        #endregion



    


        #region Update

        
        [HttpGet]//baseURL/Edit/id
        public IActionResult Edit(int? id)
        {


            if (id is null)
            {
                return BadRequest(); //Status code 400
            }
            var department = _departmentService.GetDepartmentById(id.Value);

            if (department is null)
            {
                return NotFound();
            }


            return View(new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate,
                Description = department.Description,
            });
        }


        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel departmentEditVM)
        {
            if (!ModelState.IsValid)
            {  // Server side validation
                return View(departmentEditVM);

            }
            var message = string.Empty;
            try
            {
                var department = new UpdatedDepartmentDto()
                {
                    Id = id,
                    Code = departmentEditVM.Code,
                    Name = departmentEditVM.Name,
                    CreationDate = departmentEditVM.CreationDate,
                    Description = departmentEditVM.Description,


                };

                var updated = _departmentService.UpdateDepartment(department) > 0;

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
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id is null)
        //    {
        //        return BadRequest();
        //    }
        //    var department = _departmentService.GetDepartmentById(id.Value);

        //    if (department is null)
        //    {
        //        return NotFound();
        //    }
        //    return View(department);



        //}

        [HttpPost]
        public IActionResult Delete(int id) {
            var message = string.Empty;
            try
            {
  

                var deleted = _departmentService.DeleteDepartment(id);

                if (deleted)
                    return RedirectToAction(nameof(Index));

                message = "An error has occured during deleting the department";
            }
            catch (Exception ex)
            {

                // 1.Log Exception
                _logger.LogError(ex, ex.Message);
                // 2. Set Message
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "An error has occured during deleting the department";


            }
            ModelState.AddModelError(string.Empty, message);
            return View();

        }
        #endregion

    }

    }


   
    

