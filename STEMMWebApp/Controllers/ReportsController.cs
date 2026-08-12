using Microsoft.AspNetCore.Mvc;
using STEMMWebApp.Models;

namespace STEMMWebApp.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.EnergyDaily = SampleData.EnergyDaily;
            ViewBag.CostData = SampleData.CostData;
            return View();
        }
    }
}
