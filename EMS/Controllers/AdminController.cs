using EMS.business.Abstract;
using EMS.entity;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IEmployeeService employeeService;
        private IActivityService activityService;
        public AdminController(IEmployeeService employeeService, IActivityService activityService)
        {
            this.employeeService = employeeService;
            this.activityService = activityService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEvent(string eventName, DateTime eventDate, string type, string info)
        {
            Activity activity = new Activity()
            {
                title = eventName,
                dateOfPosting = eventDate,
                activityType = type,
                description = info,
                isActive = true
            };
            activityService.Create(activity);
            return View();
        }
        public IActionResult CreateEvent()
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
        [HttpPost]
        public IActionResult NewEmployee(string idNumber, string firstName, string lastName, DateTime birthDate, string address)
        {
            Employee employee = new Employee()
            {
                identificationNumber = idNumber,
                name = firstName,
                surname = lastName,
                birthday = birthDate,
                adress = address
            };
            employeeService.Create(employee);
            return View();
        }
        public IActionResult NewEmployee()
        {
            return View();
        }

    }
}