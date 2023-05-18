using Microsoft.AspNetCore.Mvc;

namespace EMS.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEvent(string eventName)
        {
            return View();
        }
        public IActionResult CreatePayroll()
        {
            return View();
        }
        public IActionResult ViewEmployees()
        {
            return View();
        }
        public IActionResult NewEmployee()
        {
            return View();
        }
    
    }
}
