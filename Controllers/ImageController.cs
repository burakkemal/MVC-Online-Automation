using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Products.ToList();
            return View(result);
        }
    }
}