using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Staffs.ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            List<SelectListItem> deger1 = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff staff)
        {
            var result = context.Staffs.Add(staff);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetStaff(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var result = context.Staffs.Find(id);
            return View("GetStaff", result);
        }
        public ActionResult UpdateStaff(Staff staff)
        {
            var result = context.Staffs.Find(staff.StaffId);
            result.StaffName = staff.StaffName;
            result.StaffLastName = staff.StaffLastName;
            result.StaffImage = staff.StaffImage;
            result.DepartmentId = staff.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}