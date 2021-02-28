using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcProjectAli;
using MvcProjectAli.Models;
namespace MvcProjectAli.Controllers
{
    public class ReporterController : Controller
    {
        MvcProjectAliEntities db = new MvcProjectAliEntities();
        // GET: Reporter
        private MvcProjectAliEntities _context;
        public ReporterController()
        {
            _context = new MvcProjectAliEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(_context.Reporters.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Reporter user)
        {
            _context.Reporters.Add(user);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_context.Reporters.FirstOrDefault(x => x.Id == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Reporter user)
        {
            var data = _context.Reporters.FirstOrDefault(x => x.Id == user.Id);
            if (data != null)
            {
                data.Name = user.Name;
                data.State = user.State;
                data.Country = user.Country;
                data.Age = user.Age;
                _context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _context.Reporters.FirstOrDefault(x => x.Id == ID);
            _context.Reporters.Remove(data);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}