using EMS.business.Abstract;
using EMS.entity;
using EMS.WebUI.Identity;
using EMS.WebUI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace EMS.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<User> _userManager;
        private IEmployeeService employeeService;
        private IActivityService activityService;
        private IPayrollService payrollService;
        public AdminController(IEmployeeService employeeService, IActivityService activityService, UserManager<User> userManager, IPayrollService payrollService)
        {
            this.employeeService = employeeService;
            this.activityService = activityService;
            this._userManager = userManager;
            this.payrollService = payrollService;
        }
        
        
        public IActionResult Index()
        {
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

        [HttpPost]
        public IActionResult CreatePayroll(PayrollModel p)
        {
            Employee employee = employeeService.GetIdNumber(p.idNumber);
            Payroll payroll = new Payroll();
            payroll.brutMaas = p.GrossSalary;
            payroll.sgkPrimi = p.GrossSalary * 0.14;
            payroll.damgaVergisi = p.GrossSalary * 0.007;
            payroll.muhtasarVergisi = (p.GrossSalary - payroll.sgkPrimi) * 0.15;
            payroll.kesintilerToplamı = payroll.damgaVergisi + payroll.sgkPrimi;
            payroll.netMaas = p.GrossSalary - payroll.kesintilerToplamı;
            payroll.EmployeeId = employee.Id;
            payrollService.Create(payroll);
            p = new PayrollModel
            {
                employeeId = employee.Id,
                GrossSalary = payroll.brutMaas,
                SGKPremium = payroll.sgkPrimi,
                StampTax = payroll.damgaVergisi,
                MuhtasarTax = payroll.muhtasarVergisi,
                DeductionsTotal = payroll.kesintilerToplamı,
                NetSalary = payroll.netMaas,
                name = employee.name,
                surname = employee.surname
            };
            return View(p);
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

        public IActionResult ViewEvent()
        {
            List<entity.Activity> activity = activityService.GetAll();
            List<ActivityModel> models = new List<ActivityModel>();
            foreach (var item in activity)
            {
                ActivityModel activityModel = new ActivityModel();
                activityModel.type = item.activityType;
                activityModel.eventName = item.title;
                activityModel.info = item.description;
                activityModel.eventDate = item.dateOfPosting;
                // activityModel.isActive= item.isActive;
                models.Add(activityModel);
            }
            return View(models);
        }

        [HttpPost]
        public IActionResult CreateEvent(ActivityModel a)
        {
            entity.Activity activity = new entity.Activity()
            {
                activityType = a.type,
                title = a.eventName,
                description = a.info,
                dateOfPosting = a.eventDate,
            };
            activityService.Create(activity);
            return View();
        }

    }
}