using EMS.WebUI.Identity;
using EMS.WebUI.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
           /* return View(new LoginModel()
            {
               // ReturnUrl = ReturnUrl
            });*/
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {


            // var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.username);

            if (user == null)
            {
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.password, false, false);

            if (result.Succeeded)
            {
                return Redirect("/admin/index");
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            ////TempData.Put("message", new AlertMessage()
            //{
            //    Title = "Oturum Kapatıldı.",
            //    Message = "Hesabınız güvenli bir şekilde kapatıldı.",
            //    AlertType = "warning"
            //});
            return Redirect("~/");
        }

    }
}
