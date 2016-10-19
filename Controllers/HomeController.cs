<<<<<<< HEAD
﻿using omarta_v1._1.Models;
using System;
=======
<<<<<<< HEAD
﻿using omarta_v1._1.Models;
using System;
=======
﻿using System;
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace omarta_v1._1.Controllers
{
    public class HomeController : Controller
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
        private oMartaDBContext db = new oMartaDBContext();
        public ActionResult Index()
        {
            ViewBag.CategoryCount = db.Categories.Count();
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.GalleryCount = db.Galleries.Count();
            ViewBag.NewsCount = db.News.Count();
            ViewBag.SaleCount = db.Sales.Count();
<<<<<<< HEAD
=======
=======
        public ActionResult Index()
        {
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
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