using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Invoices.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddBill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBill(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}