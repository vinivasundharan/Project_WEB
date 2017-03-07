using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectCMC_Web.DAL;
using ProjectCMC_Web.Models;

namespace ProjectCMC_Web.Controllers
{
    public class CleansedTrendsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: CleansedTrends
        public ActionResult Index()
        {
            return View(db.CleansedTrend.ToList());
        }

        // GET: CleansedTrends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleansedTrend cleansedTrend = db.CleansedTrend.Find(id);
            if (cleansedTrend == null)
            {
                return HttpNotFound();
            }
            return View(cleansedTrend);
        }

        // GET: CleansedTrends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CleansedTrends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CleansedTrendID,ReadingTime,F1Amp,F2Amp,F3Amp,F4Amp,F5Amp,F1Phase,F2Phase,F3Phase,F4Phase,F5Phase,F1HA,F2HA,F3HA,F4HA,F5HA,F1HW,F2HW,F3HW,F4HW,F5HW,F1Status,F2Status,F3Status,F4Status,F5Status")] CleansedTrend cleansedTrend)
        {
            if (ModelState.IsValid)
            {
                db.CleansedTrend.Add(cleansedTrend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cleansedTrend);
        }

        // GET: CleansedTrends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleansedTrend cleansedTrend = db.CleansedTrend.Find(id);
            if (cleansedTrend == null)
            {
                return HttpNotFound();
            }
            return View(cleansedTrend);
        }

        // POST: CleansedTrends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CleansedTrendID,ReadingTime,F1Amp,F2Amp,F3Amp,F4Amp,F5Amp,F1Phase,F2Phase,F3Phase,F4Phase,F5Phase,F1HA,F2HA,F3HA,F4HA,F5HA,F1HW,F2HW,F3HW,F4HW,F5HW,F1Status,F2Status,F3Status,F4Status,F5Status")] CleansedTrend cleansedTrend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cleansedTrend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cleansedTrend);
        }

        // GET: CleansedTrends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleansedTrend cleansedTrend = db.CleansedTrend.Find(id);
            if (cleansedTrend == null)
            {
                return HttpNotFound();
            }
            return View(cleansedTrend);
        }

        // POST: CleansedTrends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CleansedTrend cleansedTrend = db.CleansedTrend.Find(id);
            db.CleansedTrend.Remove(cleansedTrend);
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
