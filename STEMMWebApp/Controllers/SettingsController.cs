using Microsoft.AspNetCore.Mvc;

namespace STEMMWebApp.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult EditProfile() => View();
    }
}
