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
        public ActionResult GetBill(int id)
        {
            var result = context.Invoices.Find(id);
            return View("GetBill", result);
        }
        public ActionResult UpdateBill(Invoice ınvoice)
        {
            var result = context.Invoices.Find(ınvoice.InvoiceId);
            result.InvoiceSerialNo = ınvoice.InvoiceSerialNo;
            result.InvoiceOrderNo = ınvoice.InvoiceOrderNo;
            result.Date = ınvoice.Date;
            result.Time = ınvoice.Time;
            result.Deliver = ınvoice.Deliver;
            result.Receive = ınvoice.Receive;
            result.TaxAdministration = ınvoice.TaxAdministration;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BillDetail(int id)
        {
            var result = context.BillPens.Where(x => x.BillId == id).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult NewPen()
        {
            return View();
        }
        public ActionResult NewPen(BillPen billPen)
        {
            context.BillPens.Add(billPen);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}