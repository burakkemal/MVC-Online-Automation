using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context context = new Context();
        public ActionResult Index()
        {
            var result1 = context.Currents.Count().ToString();
            ViewBag.d1 = result1;
            var result2 = context.Products.Count().ToString();
            ViewBag.d2 = result2;
            var result3 = context.Staffs.Count().ToString();
            ViewBag.d3 = result3;
            var result4 = context.Categories.Count().ToString();
            ViewBag.d4 = result4;
            var result5 = context.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = result5;
            var result6 = (from x in context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = result6;
            var result7 = context.Products.Count(x => x.Stock < 20).ToString();
            ViewBag.d7 = result7;
            var result8 = (from x in context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = result8;
            var result9 = (from x in context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = result9;
            var result10 = context.Products.Count(x => x.ProductName=="Buzdolabı").ToString();
            ViewBag.d10= result10;
            var result11 = context.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d11 = result11;

            var result14 = context.SalesMovements.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = result14;

            var result15 = context.SalesMovements.Count(x => x.Date ==DateTime.Today).ToString();
            ViewBag.d15 = result15;

            var result16 = context.SalesMovements.Where(x => x.Date == DateTime.Today).Sum(x => x.TotalAmount).ToString();
            ViewBag.d16 = result16;

            var result12 = context.Products.GroupBy(x => x.Brand).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.d12 = result12;
            var result13 =context.Products.Where(x=>x.ProductId==(context.SalesMovements.GroupBy(y => y.ProductId).OrderByDescending(c => c.Count()).Select(z => z.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();

            ViewBag.d13 = result13;
                return View();
        }
    }
}