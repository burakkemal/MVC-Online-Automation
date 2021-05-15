using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.SalesMovements.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            List<SelectListItem> deger1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName +" " + x.CurrentLastName,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in context.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName+" "+x.StaffLastName,
                                               Value = x.StaffId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(SalesMovement salesMovement)
        {
            salesMovement.Date = DateTime.Today;
            context.SalesMovements.Add(salesMovement);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSale(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentLastName,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in context.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StaffLastName,
                                               Value = x.StaffId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var result = context.SalesMovements.Find(id);
            return View("GetSale", result);
        }
        public ActionResult UpdateSale(SalesMovement salesMovement)
        {
            var result = context.SalesMovements.Find(salesMovement.SaleId);
            result.CurrentId = salesMovement.CurrentId;
            result.Piece = salesMovement.Piece;
            result.Price = salesMovement.Price;
            result.StaffId = salesMovement.StaffId;
            result.Date = salesMovement.Date;
            result.TotalAmount = salesMovement.TotalAmount;
            result.ProductId = salesMovement.ProductId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}