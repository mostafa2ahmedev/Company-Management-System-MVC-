using El_sheikh.MVC.PL.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace El_sheikh.MVC.PL.Controllers
{    // Action Filters
     //[AllowAnonymous] // Default Action Filter

    //[Authorize(Roles ="Admin,Customer")]  // has role admin or customer

    //[Authorize(Roles = "Admin")]
    //[Authorize(Roles = "Customer")]
    // has both Roles

    [Authorize()] // Default Authentication Schema
     public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


       
        public IActionResult Index()
        {
           
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
