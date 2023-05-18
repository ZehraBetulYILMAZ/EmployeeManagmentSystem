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

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            Employee employee1 = new Employee
            {
                identificationNumber = "111111122063",
                name = username,
                surname = password,
            };
           List<Employee> e = employeeService.GetSearchResult(username);
            LoginModel loginModel = new LoginModel
            {
                username = username,
                password = password,
            };
            return Redirect("/Admin/Index");
        }


    }
}

