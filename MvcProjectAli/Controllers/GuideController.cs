using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcProjectAli.Models;
using System.Data.Entity;

namespace MvcProjectAli.Controllers
{
    [RoutePrefix("Information")]
    public class GuideController : Controller
    {
        MvcProjectAliEntities db = new MvcProjectAliEntities();
        // GET: Guide
        [Route("List")]
        public ActionResult Index()
        {
            return View(db.Guides.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guide guide)
        {
            if (ModelState.IsValid)
            {
                db.Guides.Add(guide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guide);
        }

        public ActionResult Edit(int id = 0)
        {
            Guide guide = db.Guides.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guide guide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guide);
        }

        public ActionResult Delete(int id = 0)
        {
            Guide guide = db.Guides.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Guide guide = db.Guides.Find(id);

            db.Guides.Remove(guide);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id = 0)
        {
            Guide guide = db.Guides.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}