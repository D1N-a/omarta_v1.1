using omarta_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace omarta_v1._1.Controllers
{
    public class HomeController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();
        public ActionResult Index()
        {
            ViewBag.CategoryCount = db.Categories.Count();
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.GalleryCount = db.Galleries.Count();
            ViewBag.NewsCount = db.News.Count();
            ViewBag.SaleCount = db.Sales.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}