using Microsoft.AspNetCore.Mvc;
using STEMMWebApp.Models;

namespace STEMMWebApp.Controllers
{
    public class AlertsController : Controller
    {
        public IActionResult Index() => View(SampleData.Alerts);

        public IActionResult Detail(string id)
        {
            var alert = SampleData.Alerts.FirstOrDefault(a => a.Id == id) ?? SampleData.Alerts[0];
            return View(alert);
        }
    }
}
