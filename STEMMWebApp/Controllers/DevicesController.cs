using Microsoft.AspNetCore.Mvc;
using STEMMWebApp.Models;

namespace STEMMWebApp.Controllers
{
    public class DevicesController : Controller
    {
        public IActionResult Index()
        {
            return View(SampleData.Meters);
        }

        public IActionResult Detail(string id)
        {
            var meter = SampleData.Meters
                .FirstOrDefault(m => m.Id == id)
                ?? SampleData.Meters[0];

            return View(meter);
        }

        public IActionResult Onboard()
        {
            return View();
        }

        public IActionResult Connect()
        {
            return View();
        }

        public IActionResult Wifi()
        {
            return View();
        }

        public IActionResult Configure()
        {
            return View();
        }

        public IActionResult Complete()
        {
            return View();
        }
    }
}
