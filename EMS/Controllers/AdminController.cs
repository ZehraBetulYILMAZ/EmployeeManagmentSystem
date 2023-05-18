using EMS.business.Abstract;
using EMS.entity;
using EMS.WebUI.Model;
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
          List<Employee> employees = employeeService.GetAll();
          List<EmployeeModel> models = new List<EmployeeModel>();
            foreach (var item in employees)
            {
              EmployeeModel employeeModel = new EmployeeModel();
                employeeModel.idNumber = item.identificationNumber;
                employeeModel.firstName = item.name;
                employeeModel.lastName = item.surname;
                employeeModel.birthDate = item.birthday;
                employeeModel.address = item.adress;
                models.Add(employeeModel);
            }
            return View(models);
        }
        [HttpPost]
        public IActionResult NewEmployee(EmployeeModel e)
        {
            Employee employee = new Employee()
            {
                identificationNumber = e.idNumber,
                name = e.firstName,
                surname = e.lastName,
                birthday = e.birthDate,
                adress = e.address
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