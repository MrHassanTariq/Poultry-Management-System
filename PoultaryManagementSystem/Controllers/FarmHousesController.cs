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
    public class FarmHousesController : Controller
    {
        private PoultaryFarm db = new PoultaryFarm();

        // GET: FarmHouses
        public ActionResult Index()
        {
            return View(db.farmhouse.ToList());
        }

        // GET: FarmHouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmHouse farmHouse = db.farmhouse.Find(id);
            if (farmHouse == null)
            {
                return HttpNotFound();
            }
            return View(farmHouse);
        }

        // GET: FarmHouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmHouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmHouseID,Name,Address,orderDate")] FarmHouse farmHouse)
        {
            if (ModelState.IsValid)
            {
                db.farmhouse.Add(farmHouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farmHouse);
        }

        // GET: FarmHouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmHouse farmHouse = db.farmhouse.Find(id);
            if (farmHouse == null)
            {
                return HttpNotFound();
            }
            return View(farmHouse);
        }

        // POST: FarmHouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmHouseID,Name,Address,orderDate")] FarmHouse farmHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmHouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmHouse);
        }

        // GET: FarmHouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FarmHouse farmHouse = db.farmhouse.Find(id);
            if (farmHouse == null)
            {
                return HttpNotFound();
            }
            return View(farmHouse);
        }

        // POST: FarmHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FarmHouse farmHouse = db.farmhouse.Find(id);
            db.farmhouse.Remove(farmHouse);
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
