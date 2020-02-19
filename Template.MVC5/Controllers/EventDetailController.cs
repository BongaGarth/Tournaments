using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Template.MVC5.Controllers
{
    public class EventDetailController : Controller
    {
        // GET: EventDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventDetail/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EventDetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EventDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventDetail/Edit/5
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

        // GET: EventDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventDetail/Delete/5
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
