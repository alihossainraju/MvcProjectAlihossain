using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcProjectAli;
using System.Data.Entity;
using MvcProjectAli.Models;

namespace MvcProjectAli.Controllers
{
    public class TouristController : Controller
    {
        MvcProjectAliEntities db = new MvcProjectAliEntities();

        // GET: Trainee
        public ActionResult Index()
        {
            return View(db.Tourists.ToList());
        }

        // GET: /Trainee/Details/5

        public ActionResult Details(int id = 0)
        {
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }

        public JsonResult HotelDetails(int id)
        {
            var hotelInfo = db.Hotels.Where(e => e.TouristId == id).AsEnumerable().Select(a =>
                new
                {
                    id = a.HotelID,
                    examName = a.HotelName,
                    examDate = a.JoinDate.ToString("dd-MM-yyyy"),
                    resultDate = a.ReleaseDate.ToString("dd-MM-yyyy"),
                    totalMarks = a.Total
                });
            return Json(hotelInfo, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Trainee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trainee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tourist tourist)
        {
            if (ModelState.IsValid)
            {
                db.Tourists.Add(tourist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourist);
        }

        //
        // GET: /Trainee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }

        //
        // POST: /Trainee/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tourist tourist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourist);
        }

        //
        // GET: /Trainee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }

        //
        // POST: /Trainee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tourist tourist = db.Tourists.Find(id);
            db.Tourists.Remove(tourist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Partial_Test()
        //{
        //    return View(db.Tourists.ToList());
        //}

        public ActionResult Partial_View()
        {
            return View(db.Tourists.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }




    }
}