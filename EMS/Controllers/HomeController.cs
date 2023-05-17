using EMS.business.Abstract;
using EMS.entity;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeService employeeService;
        public HomeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        
        public IActionResult Index()
        {
            Employee employee =employeeService.GetById(1);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            Employee employee = employeeService.GetById(1);
            return RedirectToPage("Admin");
        }
    }
}

