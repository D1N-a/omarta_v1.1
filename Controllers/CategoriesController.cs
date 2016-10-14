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

namespace omarta_v1._0.Controllers
{
    public class CategoriesController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fileUpload == null)
                {
                    category.ImagePath = "/Images/standart.jpg";
                    category.Show = 1;
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    fileUpload.SaveAs(Server.MapPath("~/Images/") + Path.GetFileName(fileUpload.FileName));

                    string filename = Path.GetFileName(fileUpload.FileName);

                    category.ImagePath = "/Images/" + Path.GetFileName(fileUpload.FileName);

                    category.Show = 1;
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                Category categoryHolder = db.Categories.Where(x => x.ID == category.ID).FirstOrDefault();
                categoryHolder.Name = category.Name;
                categoryHolder.Show = category.Show;
                if (fileUpload == null)
                {
                    categoryHolder.ImagePath= categoryHolder.ImagePath;
                }
                else
                {
                    fileUpload.SaveAs(Server.MapPath("~/Images/") + Path.GetFileName(fileUpload.FileName));
                    string filename = Path.GetFileName(fileUpload.FileName);
                    categoryHolder.ImagePath = "/Images/" + Path.GetFileName(fileUpload.FileName);
                }
                //db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            if (category.Show == 1)
            {
                category.Show = 0;
            }
            else category.Show = 1;

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
