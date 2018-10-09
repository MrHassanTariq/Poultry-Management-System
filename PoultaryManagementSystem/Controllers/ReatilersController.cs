using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoultaryForm.Models;

namespace PoultaryManagementSystem.Controllers
{
    public class ReatilersController : Controller
    {
        private PoultaryFarm db = new PoultaryFarm();

        // GET: Reatilers
        public ActionResult Index()
        {
            var retailer = db.retailer.Include(r => r.Order);
            return View(retailer.ToList());
        }

        // GET: Reatilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reatiler reatiler = db.retailer.Find(id);
            if (reatiler == null)
            {
                return HttpNotFound();
            }
            return View(reatiler);
        }

        // GET: Reatilers/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.order.Where(o => o.TotalWeightLeft > 0), "OrderID", "OrderNumber");
            return View();
        }

        // POST: Reatilers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Weight,UnitPrice,PhoneNumber,Total,date,OrderID")] Reatiler reatiler)
        {
            if (ModelState.IsValid)
            {
                //updating remaining weight value of current order
                var order = db.order.Find(reatiler.OrderID);
                order.TotalWeightLeft -= reatiler.Weight;
                reatiler.Total = reatiler.Weight * reatiler.UnitPrice;
                db.retailer.Add(reatiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.order, "OrderID", "OrderNumber", reatiler.OrderID);
            return View(reatiler);
        }

        // GET: Reatilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reatiler reatiler = db.retailer.Find(id);
            if (reatiler == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.order.Where(o => o.TotalWeightLeft > 0), "OrderID", "OrderNumber", reatiler.OrderID);
            return View(reatiler);
        }

        // POST: Reatilers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Weight,UnitPrice,PhoneNumber,Total,date,OrderID")] Reatiler reatiler)
        {
            if (ModelState.IsValid)
            {
                //updating remaining weight value of current order
                var order = db.order.Find(reatiler.OrderID);
                order.TotalWeightLeft -= reatiler.Weight;
                reatiler.Total = reatiler.Weight * reatiler.UnitPrice;
                db.Entry(reatiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.order, "OrderID", "OrderNumber", reatiler.OrderID);
            return View(reatiler);
        }

        // GET: Reatilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reatiler reatiler = db.retailer.Find(id);
            if (reatiler == null)
            {
                return HttpNotFound();
            }
            return View(reatiler);
        }

        // POST: Reatilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reatiler reatiler = db.retailer.Find(id);
            db.retailer.Remove(reatiler);
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
