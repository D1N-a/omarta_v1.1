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
    public class CommentsController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Product);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,Text,Author,Status,ImagePath")] Comment comment, HttpPostedFileBase fileUpload)
        {
            
            if (ModelState.IsValid)
            {
                if (fileUpload == null)
                {
                    comment.ImagePath = null;
                    comment.Status = 0;
                    if (comment.Author == null)
                    {
                        comment.Author = "Anonim";
                    }
                    else
                    {
                        comment.Author = comment.Author;
                    }
                    db.Comments.Add(comment);
                    db.SaveChanges();
                    return RedirectToAction("ProductDetails", "User", new { id = comment.ProductID });
                }
                else
                {
                    comment.Status = 0;
                    fileUpload.SaveAs(Server.MapPath("~/Images/Comments/") + Path.GetFileName(fileUpload.FileName));
                    string filename = Path.GetFileName(fileUpload.FileName);
                    comment.ImagePath = "/Images/Comments/" + Path.GetFileName(fileUpload.FileName);
                    if (comment.Author == null)
                    {
                        comment.Author = "Anonim";
                    }
                    else
                    {
                        comment.Author = comment.Author;
                    }
                    db.Comments.Add(comment);
                    db.SaveChanges();
                    return RedirectToAction("ProductDetails","User", new { id= comment.ProductID });
                }
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", comment.ProductID);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", comment.ProductID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,Text,Author,Status,ImagePath")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", comment.ProductID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            int prod_id = comment.ProductID;
            if (comment == null)
            {
                return HttpNotFound();
            }
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Products", new { id = prod_id });
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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

        public ActionResult ShowEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            int prod_id = comment.ProductID;
            if (comment == null)
            {
                return HttpNotFound();
            }

            if (comment.Status == 1)
            {
                comment.Status = 0;
            }
            else comment.Status = 1;

            db.SaveChanges();
            return RedirectToAction("Details", "Products", new { id = prod_id });
        }
    }
}
