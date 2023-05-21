using EMS.business.Abstract;
using EMS.entity;
using EMS.WebUI.Model;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProfileDetails()
        {
            Employee employee = employeeService.GetIdNumber("12321312345");
            EmployeeModel model = new EmployeeModel()
            {
                address = employee.adress,
                birthDate = employee.birthday,
                firstName = employee.name,
                lastName = employee.surname,
                department = employee.name,
                idNumber = employee.identificationNumber,
            };
            return View(model);
        }
    }
}
