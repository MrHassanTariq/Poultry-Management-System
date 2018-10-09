using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PoulltaryFarm.Models;
using PoultaryForm.Models;
using System.Data.SqlClient;

namespace PoultaryManagementSystem.Controllers
{
    public class ReportsController : Controller
    {
        private PoultaryFarm db = new PoultaryFarm();

        // GET: Reports
        public ActionResult Index()
        {
            ViewBag.orders = db.order.ToList();
            return View();
        }

        //POST: Reports
        [HttpPost]
        public ActionResult Index(int OrderID)
        {
            ViewBag.sold =  db.retailer.Where(x=> x.Order.OrderID == OrderID).GroupBy(o => o.OrderID)
                .Select(
                    g => new
                    {
                        total = g.Sum(r=>r.Total)
                    });

            ViewBag.bought = db.order.Where(x => x.OrderID == OrderID ).Select(
                            g => new
                            {
                                total = g.Total,
                                vehicleNumber = g.Vehicle.Number,
                                farmHouseName = g.FarmHouse.Name,
                                workerName = g.Vehicle.worker.Name,
                        });

            ViewBag.orders = null;
            return View();
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(report);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] Report report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report report = db.Reports.Find(id);
            if (report == null)
            {
                return HttpNotFound();
            }
            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report report = db.Reports.Find(id);
            db.Reports.Remove(report);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Show/Reports
        public ActionResult showReports(int orderName)
        {
            //var retailers = db.retailer.Where(x => x.date == date && x.OrderID == Id );
            //string query = "SELECT SUM(total) FROM Retailer AS r WHERE r.date = date AND OrderID = id GROUP BY OrderID ";
            //SqlParameter date = new SqlParameter("date", date );
            //SqlParameter id = new SqlParameter("id", id);
            //var Profits =  db.Departments.SqlQuery(query, id).SingleOrDefaultAsync();

            

            return RedirectToAction("Details");
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
