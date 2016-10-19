using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using omarta_v1._1.Models;
using System.IO;

namespace omarta_v1._1.Controllers
{
    public class GalleriesController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();

        // GET: Galleries
        public ActionResult Index()
        {
<<<<<<< HEAD
            ViewBag.Photo = db.Photos.ToList();
=======
<<<<<<< HEAD
            ViewBag.Photo = db.Photos.ToList();
=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
            return View(db.Galleries.ToList());
        }

        // GET: Galleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
        public ActionResult Create([Bind(Include = "ID,Name,Cover")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
<<<<<<< HEAD
=======
=======
        public ActionResult Create([Bind(Include = "ID,Name,Cover")] Gallery gallery, HttpPostedFileBase cover)
        {
            if (ModelState.IsValid)
            {
                if (cover == null)
                {
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
                    gallery.Cover = "/Images/standart.jpg";
                    db.Galleries.Add(gallery);
                    db.SaveChanges();
                    return RedirectToAction("Index");
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
                }
                else
                {
                    cover.SaveAs(Server.MapPath("~/Images/News") + Path.GetFileName(cover.FileName));

                    string filename = Path.GetFileName(cover.FileName);

                    gallery.Cover = "/Images/News" + Path.GetFileName(cover.FileName);

                    db.Galleries.Add(gallery);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
            }

            return View(gallery);
        }

        // GET: Galleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Galleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Cover")] Gallery gallery, HttpPostedFileBase cover)
        {
            if (ModelState.IsValid)
            {
                Gallery holder = db.Galleries.Where(x => x.ID == gallery.ID).FirstOrDefault();
                holder.Name = gallery.Name;
<<<<<<< HEAD
                holder.Cover = holder.Cover;
=======
<<<<<<< HEAD
                holder.Cover = holder.Cover;
=======
                if (cover == null)
                {
                    holder.Cover = holder.Cover;
                }
                else
                {
                    cover.SaveAs(Server.MapPath("~/Images/News") + Path.GetFileName(cover.FileName));
                    string filename = Path.GetFileName(cover.FileName);
                    holder.Cover = "/Images/News" + Path.GetFileName(cover.FileName);
                }
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            db.Galleries.Remove(gallery);
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
