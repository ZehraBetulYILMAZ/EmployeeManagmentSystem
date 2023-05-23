using EMS.business.Abstract;
using EMS.entity;
using EMS.WebUI.Model;
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
            return View();
        }

    


    }
}

