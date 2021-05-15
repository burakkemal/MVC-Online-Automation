using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Categories.ToList();
            return View(result);
           }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var result = context.Categories.Find(id);
            context.Categories.Remove(result);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var result = context.Categories.Find(id);
            return View("GetCategory", result);
        }
        public ActionResult UpdateCategory(Category category)
        {
            var result = context.Categories.Find(category.CategoryId);
            result.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}