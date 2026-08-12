using Microsoft.AspNetCore.Mvc;
using STEMMWebApp.Models;

namespace STEMMWebApp.Controllers
{
    public class DevicesController : Controller
    {
        public IActionResult Index() => View(SampleData.Meters);

        public IActionResult Detail(string id)
        {
            var meter = SampleData.Meters.FirstOrDefault(m => m.Id == id) ?? SampleData.Meters[0];
            return View(meter);
        }

        public IActionResult Onboard() => View();
    }
}
