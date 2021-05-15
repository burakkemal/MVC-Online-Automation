using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Products.Where(x=>x.Status==true).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");                
        }
        public ActionResult DeleteProduct(int id)
        {
            var resulut = context.Products.Find(id);
            resulut.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            var result = context.Products.Find(id);
            return View("GetProduct", result);
        }
        public ActionResult UpdateProduct(Product product)
        {
            var result = context.Products.Find(product.ProductId);
            result.PurchasePrice = product.PurchasePrice;
            result.SalePrice = product.SalePrice;            
            result.Stock = product.Stock;
            result.ProductName = product.ProductName;
            result.CategoryId = product.CategoryId;
            result.ProductImage = product.ProductImage;
            result.Brand = product.Brand;
            result.Status = product.Status;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ProductList()
        {
            var result = context.Products.ToList();
            return View(result);
        }
    }
}