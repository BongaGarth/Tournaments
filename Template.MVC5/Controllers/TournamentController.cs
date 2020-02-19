using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.BusinessLogic.Tournament;
using Template.Model.ViewModels;

namespace Template.MVC5.Controllers
{
    public class TournamentController : Controller
    {

        private readonly ITournamentBusiness _tournament;

        public TournamentController(ITournamentBusiness tournament)
        {
            _tournament = tournament;
        }

        // GET: Tournament
        public ActionResult Index(string searchString, string Filter_Value, int? Page_No)
        {
            if (searchString != null)
            {
                Page_No = 1;
            }
            else
            {
                searchString = Filter_Value;
            }

            ViewBag.FilterValue = searchString;

            var list = _tournament.GetAllTournaments();




            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(stu => stu.TournamentName.ToUpper().Contains(searchString.ToUpper())).ToList();

            }

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(list.ToPagedList(No_Of_Page, Size_Of_Page));
        }
        public ActionResult Create()
        {
            var tournament = new TournamentModel();
            return View(tournament);
        }

        // POST: Material/Create
        [HttpPost]
        public ActionResult Create(TournamentModel model)
        {
            try
            {
                // TODO: Add insert logic here
                _tournament.AddTournament(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Tournament/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tournament/Edit/5
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

        // GET: Tournament/Delete/5
        public ActionResult Delete(int id)
        {
            var tournament = _tournament.GetById(id);
            return View(tournament);
        }

        // POST: Tournament/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TournamentViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _tournament.Delete(model.TournamentID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult TournamentEvents(int? Page_No, int  TournamentID)
        {
            Session["TournamentID"] = TournamentID;

            var tournament = _tournament.GetAllTournaments().SingleOrDefault(p => p.TournamentID.Equals(TournamentID));
            Session["TournamentName"] = tournament.TournamentName;

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(tournament.Events.ToPagedList(No_Of_Page, Size_Of_Page));
        }

    }
}
