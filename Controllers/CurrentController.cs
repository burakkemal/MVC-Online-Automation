using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Currents.Where(x=>x.Status==true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current current)
        {
            current.Status = true;
            context.Currents.Add(current);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var result = context.Currents.Find(id);
            result.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int id)
        {
            var result = context.Currents.Find(id);
            return View("GetCurrent",result);
        }
        public ActionResult UpdateCurrent(Current current)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            var result = context.Currents.Find(current.CurrentId);
            result.CurrentName = current.CurrentName;
            result.CurrentLastName = current.CurrentLastName;
            result.CurrentCity = current.CurrentCity;
            result.CurrentMail = current.CurrentMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSale(int id)
        {
            var result = context.SalesMovements.Where(x => x.CurrentId == id).ToList();
            var cr = context.Currents.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentLastName).FirstOrDefault();
            ViewBag.cari = cr;
            return View(result);
        }
    }
}