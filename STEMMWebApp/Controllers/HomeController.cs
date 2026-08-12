using Microsoft.AspNetCore.Mvc;
using STEMMWebApp.Models;
using System.Diagnostics;

namespace STEMMWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Departments = SampleData.Departments;
            ViewBag.Alerts = SampleData.Alerts;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
