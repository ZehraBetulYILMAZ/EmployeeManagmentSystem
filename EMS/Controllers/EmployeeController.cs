using EMS.business.Abstract;
using EMS.entity;
using EMS.WebUI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebUI.Controllers
{
    [Authorize(Roles = "employee")]
    public class EmployeeController : Controller
    {

        private IEmployeeService employeeService;
        private ITaskService taskService;
        private IActivityService activityService;
        public EmployeeController(IEmployeeService employeeService, ITaskService taskService, IActivityService activityService)
        {
            this.employeeService = employeeService;
            this.taskService = taskService;
            this.activityService = activityService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmployeeViewEvent(ActivityModel model)
        {
            Employee employee = employeeService.GetById(model.EmployeeId);
            Activity activity = activityService.GetById(model.Id);
            if (activity != null && employee != null)
            {
                activityService.UpdateAttandes(employee, activity);
            }
            return View();
           
        }
        public IActionResult EmployeeViewEvent()
        {
            Employee employee = employeeService.GetIdNumber("12321312345");
            var a = activityService.GetActivityWithEmployee(employee);
            List<ActivityModel>models = new List<ActivityModel>();
            foreach (var item in a)
            {
                ActivityModel model = new ActivityModel()
                {
                    Id = item.Id,
                    eventDate = item.dateOfPosting,
                    eventName = item.activityType,
                    info = item.description,
                    EmployeeId = employee.Id,

                };
                models.Add(model);
            }
            return View(models);
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

        public IActionResult ViewTask()
        {
            Employee employee = employeeService.GetById(1);
            var tasks = taskService.GetTasksWithEmployee(employee.Id);
            List<TaskModel> models = new List<TaskModel>();
            foreach (var task in tasks)
            {
                TaskModel model = new TaskModel()
                {
                    Id = task.Id,
                    name = task.name,
                    description = task.name,
                    dateOfPosting = task.dateOfPosting,
                    status = task.status
                };
                models.Add(model);
            }

            return View(models);
        }
     
        [HttpPost]
        public IActionResult TaskStatus(TaskModel model)
        {
            var task = taskService.GetById(model.Id);

            if (model.status != null)
            {
                task.status = model.status;
                taskService.Update(task);
            }
           


            return View(model);
        }
    }
}
