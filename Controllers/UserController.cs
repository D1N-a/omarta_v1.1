using omarta_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}