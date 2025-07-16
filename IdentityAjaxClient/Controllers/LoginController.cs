using Microsoft.AspNetCore.Mvc;

namespace IdentityAjaxClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View(); // sẽ tìm Views/Login/Login.cshtml
        }
        public IActionResult Register()
        {
            return View();
        }
    }


}
