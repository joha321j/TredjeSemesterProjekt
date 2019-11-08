using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vitec.Models;
using VitecData;
using VitecData.ServiceInterfaces;

namespace Vitec.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserService userService, VitecContext context)
        {
            _logger = logger;

            if (!context.Users.Any())
            {
                userService.CreateNewUser("Doduchis", "a", "Emilie", "Holst", "Kohaven 20", 1699);
                userService.CreateNewUser("Forculd", "a", "Nina", "Jepsen", "Grønvejen 46", 3210);
                userService.CreateNewUser("MarBri", "a", "Marianne", "Briansen", "Maevej 41", 5690);
            }
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
