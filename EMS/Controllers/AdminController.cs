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
        private RoleManager<IdentityRole> roleManager;
        private ITaskService taskService;
        public AdminController(IEmployeeService employeeService, IActivityService activityService, UserManager<User> userManager, IPayrollService payrollService, RoleManager<IdentityRole> roleManager, ITaskService taskService)
        {
            this.employeeService = employeeService;
            this.activityService = activityService;
            this._userManager = userManager;
            this.payrollService = payrollService;
            this.roleManager = roleManager;
            this.taskService = taskService;
        }

        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonmembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name)
                                ? members : nonmembers;
                list.Add(user);
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
            }
            return Redirect("/admin/role/" + model.RoleId);
        }

        public IActionResult RoleList()
        {
            return View(roleManager.Roles);
        }
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
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
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });
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
        public IActionResult AssignTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AssignTask(TaskModel model)
        {
            TaskEmployee task = new TaskEmployee();
            task.dateOfPosting = DateTime.Now;
            task.description = model.description;
            task.name =model.name;
            task.EmployeeId = model.EmployeeId;
            task.isActive = true;
            task.dateOfHanding = model.dateOfHanding;
            task.status = "not";
            taskService.Create(task);
            return View();
        }
        public IActionResult UploadLetter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadLetter(IFormFile file,string idNumber)
        {
            //string idNumer = "1100110011";
            var entity = employeeService.GetIdNumber(idNumber);



            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                entity.offerLetterPath = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", randomName);

                var stream = new FileStream(path, FileMode.Create);

                file.CopyTo(stream);
            }
            employeeService.Update(entity);


            return View();
        }
    }
}
