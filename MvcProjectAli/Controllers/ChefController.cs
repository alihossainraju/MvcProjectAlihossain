using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// Add new namespase
using System.Threading.Tasks;
using AutoMapper;
using MvcProjectAli.ViewModels;
using MvcProjectAli.Models;
using System.Net;
using System.Data.Entity;
using PagedList;

namespace MvcProjectAli.Controllers
{
    public class ChefController : Controller
    {

        private MvcProjectAliEntities db = new MvcProjectAliEntities();
        //// GET: Chef
        //public ActionResult Index()
        //{
        //    return View();
        //}


        // (Start - 01) sortOrder for sorting, searchString for filtering and currentFilter, page for pagging
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else { searchString = currentFilter; }
            ViewBag.CurrentFilter = searchString;
            var chefs = from s in db.Chefs
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                chefs = chefs.Where(s => s.ChefName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    chefs = chefs.OrderByDescending(s => s.ChefName);
                    break;
                default:
                    chefs = chefs.OrderBy(s => s.ChefName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(chefs.ToPagedList(pageNumber, pageSize));
        }
        // (End - 01)


        // GET: Details
        //[Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = db.Chefs.Single(t => t.ChefID == id);
            var chef = Mapper.Map<Chef, ChefVB>(query);
            if (chef == null)
            {
                return HttpNotFound();
            }
            return View(chef);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChefVB chefVB)
        {
            if (ModelState.IsValid)
            {
                var chef = Mapper.Map<Chef>(chefVB);
                db.Chefs.Add(chef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chefVB);
        }

        // GET: Edit
        public ActionResult Edit(int? id)
        {
            var query = db.Chefs.Single(t => t.ChefID == id);
            var chef = Mapper.Map<Chef, ChefVB>(query);
            return View(chef);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChefVB chefVB)
        {
            if (ModelState.IsValid)
            {
                var chef = Mapper.Map<Chef>(chefVB);
                db.Entry(chef).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chefVB);
        }

        // GET: Delete
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            var query = db.Chefs.Single(t => t.ChefID == id);
            var chef = Mapper.Map<Chef, ChefVB>(query);
            return View(chef);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, ChefVB chefVB)
        {
            var query = db.Chefs.Single(t => t.ChefID == id);
            var chef = Mapper.Map<Chef, ChefVB>(query);
            db.Chefs.Remove(query);  // 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}