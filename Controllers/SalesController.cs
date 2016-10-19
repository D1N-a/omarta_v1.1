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
    public class SalesController : Controller
    {
        private oMartaDBContext db = new oMartaDBContext();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Product);
            return View(sales.ToList());
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,Salesdate,Quantity")] Sales sales)
        {
            if (ModelState.IsValid)
            {
                Products holder = db.Products.Where(x => x.ID == sales.ProductID).FirstOrDefault();
                holder.AvailableQuantity = holder.AvailableQuantity - sales.Quantity;
                db.Sales.Add(sales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ID", "Name", sales.ProductID);
            return View(sales);
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
