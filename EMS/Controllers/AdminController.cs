using EMS.business.Abstract;
using EMS.entity;
using EMS.WebUI.Identity;
using EMS.WebUI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace EMS.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<User> _userManager;
        private IEmployeeService employeeService;
        private IActivityService activityService;
        public AdminController(IEmployeeService employeeService, IActivityService activityService, UserManager<User> userManager)
        {
            this.employeeService = employeeService;
            this.activityService = activityService;
            this._userManager = userManager;
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
        public async Task<IActionResult> NewEmployee(EmployeeModel e)
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
            var user = new User()
            {
              Email = employee.adress,
              identificationNumber = employee.identificationNumber,
              UserName = employee.name + employee.surname
            };
            var result = await _userManager.CreateAsync(user, "N8hZ4V9#%g0u");
            if (result.Succeeded)
            {
                // generate token
                // email
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public IActionResult NewEmployee()
        {
            return View();
        }

    }
}