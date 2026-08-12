using Microsoft.AspNetCore.Mvc;
using STEMMWebApp.Models;

namespace STEMMWebApp.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index() => View(SampleData.Notifications);
    }
}
