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
    public class OrdersController : Controller
    {
        private PoultaryFarm db = new PoultaryFarm();

        // GET: Orders
        public ActionResult Index()
        {
            var order = db.order.Include(o => o.FarmHouse).Include(o => o.Vehicle);
            return View(order.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.FarmHouseID = new SelectList(db.farmhouse, "FarmHouseID", "Name");
            ViewBag.VehicleID = new SelectList(db.vehicle, "VehicleID", "Number");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,Weight,unitPrice,OrderNumber,date,TotalWeightLeft,Total,FarmHouseID,VehicleID")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.TotalWeightLeft = order.Weight;
                order.Total = order.Weight * order.unitPrice;
                db.order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmHouseID = new SelectList(db.farmhouse, "FarmHouseID", "Name", order.FarmHouseID);
            ViewBag.VehicleID = new SelectList(db.vehicle, "VehicleID", "Number", order.VehicleID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmHouseID = new SelectList(db.farmhouse, "FarmHouseID", "Name", order.FarmHouseID);
            ViewBag.VehicleID = new SelectList(db.vehicle, "VehicleID", "Number", order.VehicleID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,Weight,unitPrice,OrderNumber,date,TotalWeightLeft,Total,FarmHouseID,VehicleID")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.TotalWeightLeft = order.Weight;
                order.Total = order.Weight * order.unitPrice;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmHouseID = new SelectList(db.farmhouse, "FarmHouseID", "Name", order.FarmHouseID);
            ViewBag.VehicleID = new SelectList(db.vehicle, "VehicleID", "Number", order.VehicleID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.order.Find(id);
            db.order.Remove(order);
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
