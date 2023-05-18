using Microsoft.AspNetCore.Mvc;

namespace EMS.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
