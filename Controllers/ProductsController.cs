using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using omarta_v1._1.Models;

namespace omarta_v1._1.Controllers
{
    public class ProductsController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
<<<<<<< HEAD
            var galleryid = products.GalleryID;
            ViewBag.Gallery = db.Photos.Where(x=>x.GalleryID== galleryid).ToList();
            ViewBag.Comment = db.Comments.Where(x => x.ProductID == id).ToList();
=======
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
<<<<<<< HEAD
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name");
=======
<<<<<<< HEAD
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name");
=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public ActionResult Create([Bind(Include = "ID,Name,SalesPrice,BuyPrice,Description,Quantity,AvailableQuantity,LastChange,CategoryID,GalleryID")] Products products)
=======
<<<<<<< HEAD
        public ActionResult Create([Bind(Include = "ID,Name,SalesPrice,BuyPrice,Description,Quantity,AvailableQuantity,LastChange,CategoryID,GalleryID")] Products products)
=======
        public ActionResult Create([Bind(Include = "ID,Name,SalesPrice,BuyPrice,Description,Quantity,AvailableQuantity,LastChange,CategoryID")] Products products)
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
        {
            if (ModelState.IsValid)
            {
                products.LastChange = DateTime.Now;
                products.AvailableQuantity = products.Quantity;
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", products.CategoryID);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
<<<<<<< HEAD
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name", products.GalleryID);
=======
<<<<<<< HEAD
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name", products.GalleryID);
=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", products.CategoryID);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SalesPrice,BuyPrice,Description,Quantity,AvailableQuantity,LastChange,CategoryID")] Products products)
        {
            if (ModelState.IsValid)
            {
                Products holder = db.Products.Where(x => x.ID == products.ID).FirstOrDefault();
                holder.LastChange = DateTime.Now;
                holder.AvailableQuantity = products.Quantity + holder.AvailableQuantity;
                holder.BuyPrice = products.BuyPrice;
                holder.CategoryID = products.CategoryID;
                holder.Category = products.Category;
                holder.Description = products.Description;
                holder.Name = products.Name;
                holder.Quantity = products.Quantity;
                holder.SalesPrice = products.SalesPrice;
<<<<<<< HEAD
                holder.GalleryID = products.GalleryID;
                holder.Gallery = products.Gallery;

=======
<<<<<<< HEAD
                holder.GalleryID = products.GalleryID;
                holder.Gallery = products.Gallery;

=======
  
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7

                //db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", products.CategoryID);
<<<<<<< HEAD
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name", products.GalleryID);
=======
<<<<<<< HEAD
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name", products.GalleryID);
=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
