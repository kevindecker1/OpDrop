using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpDrop.NETCoreTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OpDrop.NETCoreTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CancelOpDrop()
        {
            OpDrop.Worker.Cancel("1");

            return Json(true);
        }

        public IActionResult Privacy()
        {
            OpDrop.Worker.Run("1", () =>
            {
                System.Diagnostics.Debug.WriteLine("OpDrop Test");
                System.Threading.Thread.Sleep(20000); // 20 seconds
            });

            var error = OpDrop.Worker.GetError("1");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
