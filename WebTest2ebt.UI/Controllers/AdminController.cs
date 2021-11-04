using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTest2ebt.UI.AppConfiguration;

namespace WebTest2ebt.UI.Controllers
{
    [Authorize(Roles = RolesNames.Admin)]
    public class AdminController : Controller
    {
        // GET: AdminController
        [Authorize(Roles = RolesNames.Admin)]
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController
        [Authorize(Roles = RolesNames.Admin)]
        public ActionResult EquipmentDetails()
        {
            return View();
        }

        // GET: AdminController
        [Authorize(Roles = RolesNames.Admin)]
        public ActionResult BuyersList()
        {
            return View();
        }

        // GET: AdminController
        [Authorize(Roles = RolesNames.Admin)]
        public ActionResult Services()
        {
            return View();
        }

        // GET: AdminController
        [Authorize(Roles = RolesNames.Admin)]
        public ActionResult MasterDetails()
        {
            return View();
        }

        // GET: AdminController
        [Authorize(Roles = RolesNames.Admin)]
        public ActionResult Orders()
        {
            return View();
        }

        // GET: AdminController
        [Authorize(Roles = RolesNames.Admin)]
        public ActionResult OrdersHistory()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Create(IFormCollection collection)
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

        // GET: AdminController/Edit/5
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
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

        // GET: AdminController/Delete/5
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesNames.Admin)]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
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
    }
}
