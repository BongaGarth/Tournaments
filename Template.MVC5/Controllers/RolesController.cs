using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BusinessLogic;
using Template.Model.Models;

namespace Template.MVC5.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private readonly IRegisterBusiness _registerbusiness;

        public RolesController(RegisterBusiness registerbusiness)
        {
            _registerbusiness = registerbusiness;
        }

        // GET: Roles
        private readonly RoleBusiness _reolesrepo = new RoleBusiness();
        public ActionResult Index()
        {
            var list = _registerbusiness.GetAllRoles();
            return View(list);
        }

        // GET: Roles/Details/5
        public ActionResult UserRoles(string id)
        {
            var users = _registerbusiness.UsersRoles(id);
            return View(users);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            var role = new RoleModel();
            return View(role);
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(RoleModel model)
        {
            try
            {

                if(_registerbusiness.RoleExists(model.RoleName))
                {
                    ModelState.AddModelError("", "Role already exists");
                    return View(model);
                }
                _registerbusiness.CreateRole(model.RoleName);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
