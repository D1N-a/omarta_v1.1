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
<<<<<<< HEAD
using System.Text;
=======
<<<<<<< HEAD
using System.Text;
=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7

namespace omarta_v1._1.Controllers
{
    public class NewsController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();

        // GET: News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
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

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,Show,Newsdate,Title,ImagePath,Text")] News news, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fileUpload == null)
                {
                    news.ImagePath = "/Images/standart.jpg";
                    news.Show = 1;
                    db.News.Add(news);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    fileUpload.SaveAs(Server.MapPath("~/Images/News/") + Path.GetFileName(fileUpload.FileName));

                    string filename = Path.GetFileName(fileUpload.FileName);

                    news.ImagePath = "/Images/News/" + Path.GetFileName(fileUpload.FileName);

                    news.Show = 1;
                    db.News.Add(news);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Show,Newsdate,Title,ImagePath,Text")] News news, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                News newsHolder = db.News.Where(x => x.ID == news.ID).FirstOrDefault();
                newsHolder.Title = news.Title;
                newsHolder.Show = news.Show;
                newsHolder.Newsdate = news.Newsdate;
                newsHolder.Text = news.Text;
                if (fileUpload == null)
                {
                    newsHolder.ImagePath = newsHolder.ImagePath;
                }
                else
                {
                    fileUpload.SaveAs(Server.MapPath("~/Images/News") + Path.GetFileName(fileUpload.FileName));
                    string filename = Path.GetFileName(fileUpload.FileName);
                    newsHolder.ImagePath = "/Images/News" + Path.GetFileName(fileUpload.FileName);
                }
                //db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
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
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowEdit(int? id)
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

            if (news.Show == 1)
            {
                news.Show = 0;
            }
            else news.Show = 1;

            db.SaveChanges();
            return RedirectToAction("Details", new { id=news.ID});
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
<<<<<<< HEAD

=======
<<<<<<< HEAD

=======
>>>>>>> d659a7aad95dd4c8b46f6e113cf497211aa6848e
>>>>>>> 01aa43a9bd2c6603bcfe8cd5bed8dc3c996744c7
