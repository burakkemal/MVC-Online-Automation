using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Departments.Where(x=>x.Status==true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDepartment(int id)
        {
            var resulut = context.Departments.Find(id);
            resulut.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDepartment(int id)
        {
            var result = context.Departments.Find(id);
            return View("GetDepartment",result);
        }
        public ActionResult UpdateDepartment(Department department)
        {
            var result = context.Departments.Find(department.DepartmentId);
            result.DepartmentName = department.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            var result = context.Staffs.Where(x => x.DepartmentId == id).ToList();
            var dpt = context.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(result);
        }
        public ActionResult DepartmentStaffSales(int id)
        {
            var result = context.SalesMovements.Where(x => x.StaffId == id).ToList();
            var per = context.Staffs.Where(x => x.StaffId == id).Select(y => y.StaffName +  " "+y.StaffLastName).FirstOrDefault();
            ViewBag.dpers = per;
            return View(result);                 
        }
      
    }
}