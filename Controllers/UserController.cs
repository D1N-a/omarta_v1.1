using omarta_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Net;
=======
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
using System.Web;
using System.Web.Mvc;

namespace omarta_v1._1.Controllers
{
    public class UserController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();
        // GET: User
        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.Where(x => x.Show == 1).ToList();
            ViewBag.News = db.News.Where(x => x.Show == 1).OrderByDescending(x => x.Newsdate).Take(3);
            return View();
        }

        public ActionResult News()
        {
            ViewBag.News = db.News.Where(x => x.Show == 1).ToList();
            return View();
        }
<<<<<<< HEAD

        public ActionResult NewsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        public ActionResult Products(int? id)
        {
            ViewBag.Categories = db.Categories.Where(w => w.Show == 1).ToList();
            if (id == null || id == 0)
            {
                ViewBag.Products = db.Products.Where(x => x.Category.Show == 1).ToList();
            }
            else
            {
                ViewBag.Products = db.Products.Where(x => x.Category.Show == 1 && x.CategoryID == id).ToList();
            }
            
            return View();
        }

        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Products = db.Products.Find(id);
            var products = db.Products.Find(id);
            var galleryid = products.GalleryID;
            ViewBag.Gallery = db.Photos.Where(x => x.GalleryID == galleryid).ToList();
            ViewBag.Comments = db.Comments.Where(v=>v.Status==1 && v.ProductID == id).ToList();
            if (products == null)
            {
                return HttpNotFound();
            }
            return View();
        }
=======
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
    }
}