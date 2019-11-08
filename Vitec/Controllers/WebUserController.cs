using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Vitec.Models;
using VitecData.ServiceInterfaces;

namespace Vitec.Controllers
{
    public class WebUserController : Controller
    {
        private IUserService _userService;

        public WebUserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Login Page
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                Response.Redirect("AccountDetails");
            }
            return View(new LoginViewModel());
        }

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Details");
                //return RedirectToAction("Details", "User");
            }

            if (await _userService.LoginUser(username, password))
            {
                return RedirectToAction("Details");
                //Response.Redirect("/AccountDetails");
            }

            var model = new LoginViewModel
            {
                Username = username,
                Error = "Kunne ikke logge ind, prøv igen."
            };

            return View(model);
        }

        [Route("logout")]
        public async Task<IActionResult> SignOut()
        {
            await _userService.SignOutUser();
            return RedirectToAction(nameof(Index));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details
        //[Route("AccountDetails")]
        [Authorize]
        public IActionResult Details()
        {
            var model = new WebUserViewModel
            {
                Username = "lol"
            };

            return View(model);
        }

        

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}