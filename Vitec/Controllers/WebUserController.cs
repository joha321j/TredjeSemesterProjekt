using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VitecData.Models;
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

        [Authorize(Roles = Constants.AdministratorRoleName)]
        public async Task<ActionResult> Index()
        {
            var model = await _userService.GetAllUsers();
            return View(model);
        }

        // GET: WebUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WebUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WebUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WebUser/Edit/5
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

        // GET: WebUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WebUser/Delete/5
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