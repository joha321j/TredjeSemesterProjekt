using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vitec.Models;

namespace Vitec.Controllers
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
            _logger.LogDebug("User has accessed /Home/Index");
            return View();
        }

        public IActionResult Login()
        {
            _logger.LogDebug("User has accessed /Home/Login");
            return View();
        }

        public IActionResult Contact()
        {
            _logger.LogDebug("User has accessed /Home/Contact");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogDebug("User has accessed /Home/Privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Shit went down.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
