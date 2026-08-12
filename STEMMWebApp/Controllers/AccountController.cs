using Microsoft.AspNetCore.Mvc;

namespace STEMMWebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        // UI only for now — any submit just goes straight to the dashboard.
        [HttpPost]
        public IActionResult Login(string? email, string? password)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout() => RedirectToAction("Login");
    }
}
