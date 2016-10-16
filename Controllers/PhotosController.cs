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
    public class PhotosController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();

        // GET: Photos
        public ActionResult Index(int? id)
        {
            ViewBag.GalleryID = id;
            var g = db.Galleries.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.GalleryName = g.Name;
            var ph = db.Photos.Where(x => x.GalleryID == id);
            //var photos = db.Photos.Include(p => p.Gallery);
<<<<<<< HEAD
            //ViewBag.Photo = ph.ToList();
=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
            return View(ph.ToList());
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create(int? id)
        {
            ViewBag.Gallery = id;
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name");
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ImagePath,GalleryID")] Photo photo, HttpPostedFileBase fileUpload, int id)
        {
            if (ModelState.IsValid)
            {
                if (fileUpload == null)
                {
                    photo.GalleryID = id;
                    photo.ImagePath = "/Images/standart.jpg";
                    db.Photos.Add(photo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    fileUpload.SaveAs(Server.MapPath("~/Images/Products/") + Path.GetFileName(fileUpload.FileName));

                    string filename = Path.GetFileName(fileUpload.FileName);

                    photo.ImagePath = "/Images/Products/" + Path.GetFileName(fileUpload.FileName);
                    photo.GalleryID = id;
                    db.Photos.Add(photo);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = photo.GalleryID });
                }
            }

            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name", photo.GalleryID);
            return View(photo);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name", photo.GalleryID);
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImagePath,GalleryID")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GalleryID = new SelectList(db.Galleries, "ID", "Name", photo.GalleryID);
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
<<<<<<< HEAD
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = photo.GalleryID });
=======
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Index");
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
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
