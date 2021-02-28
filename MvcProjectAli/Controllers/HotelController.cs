using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcProjectAli;
using MvcProjectAli.Models;

namespace MvcProjectAli.Controllers
{
    public class HotelController : Controller
    {
        MvcProjectAliEntities db = new MvcProjectAliEntities();
        // GET: Exam
        public ActionResult Index()
        {
            var hotelDetails = db.Hotels.Include(t =>t.Tourist);
            return View(hotelDetails.ToList());
        }


        public ActionResult Details(int id = 0)
        {
            Hotel hoteldetail = db.Hotels.Find(id);
            if (hoteldetail == null)
            {
                return HttpNotFound();
            }
            return View(hoteldetail);
        }

        //
        // GET: /Exam/Create

        public ActionResult Create()
        {
            ViewBag.TouristId = new SelectList(db.Tourists, "TouristId", "TouristName");   //for dropdown
            return View();
        }

        //
        // POST: /Exam/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hoteldetail)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hoteldetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TouristId = new SelectList(db.Tourists, "TouristId", "TouristName", hoteldetail.TouristId); //for dropdown
            return View(hoteldetail);
        }

        //
        // GET: /Exam/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hotel hoteldetail = db.Hotels.Find(id);
            if (hoteldetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.TouristId = new SelectList(db.Tourists, "TouristId", "TouristName", hoteldetail.TouristId); //for dropdown
            return View(hoteldetail);
        }

        //
        // POST: /Exam/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hotel hoteldetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoteldetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TouristId = new SelectList(db.Tourists, "TouristId", "TouristName", hoteldetail.TouristId); //for dropdown
            return View(hoteldetail);
        }

        //
        // GET: /Exam/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hotel hoteldetail = db.Hotels.Find(id);
            if (hoteldetail == null)
            {
                return HttpNotFound();
            }
            return View(hoteldetail);
        }

        //
        // POST: /Exam/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hoteldetail = db.Hotels.Find(id);
            db.Hotels.Remove(hoteldetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}