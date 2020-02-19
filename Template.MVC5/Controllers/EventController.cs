using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BusinessLogic.EventBusiness;
using Template.Model.Models;
using Template.Model.ViewModels;

namespace Template.MVC5.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventservice;

        public EventController(IEventService eventservice)
        {
            _eventservice = eventservice;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event/Details/5

        public ActionResult EventDetails(int? Page_No, int EventID)
        {
            var eventT = _eventservice.GetAllEvents().SingleOrDefault(p => p.EventID.Equals(EventID));
            Session["EventName"] = eventT.EventName;

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(eventT.Details.ToPagedList(No_Of_Page, Size_Of_Page));
        }
        // GET: Event/Create
        public ActionResult Create(int TournamentID)
        {
            var eventitem = new EventModel { TournamentID=TournamentID};
            return View(eventitem);
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventModel model)
        {
            try
            {
                // TODO: Add insert logic here
                _eventservice.AddEvent(model);
                return RedirectToAction("TournamentEvents", "Tournament",new { TournamentID=Session["TournamentID"] });
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
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

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
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
