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
    public class WindMillsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: WindMills
        public ActionResult Index()
        {
            var windMill = db.WindMill.Include(w => w.WindPark);
            return View(windMill.ToList());
        }

        // GET: WindMills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindMill windMill = db.WindMill.Find(id);
            if (windMill == null)
            {
                return HttpNotFound();
            }
            return View(windMill);
        }

        // GET: WindMills/Create
        public ActionResult Create()
        {
           ViewBag.WindParkID = new SelectList(db.WindPark, "WindParkID", "WindParkName");
            return View();
        }

        // POST: WindMills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WindMillID,WindMillName,CreatedOn,ModifiedOn,CreatedBy,ModifiedBy,ManufacturerName,Latitude,Longtitude,WindParkID")] WindMill windMill)
        {
            if (ModelState.IsValid)
            {
                windMill.CreatedBy = User.Identity.Name;
                windMill.CreatedOn = DateTime.Now;
                windMill.ModifiedOn = DateTime.Now;
                windMill.ModifiedBy = User.Identity.Name;
                db.WindMill.Add(windMill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WindParkID = new SelectList(db.WindPark, "WindParkID", "WindParkName", windMill.WindParkID);
            return View(windMill);
        }

        // GET: WindMills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindMill windMill = db.WindMill.Find(id);
            if (windMill == null)
            {
                return HttpNotFound();
            }
            ViewBag.WindParkID = new SelectList(db.WindPark, "WindParkID", "WindParkName", windMill.WindParkID);
            return View(windMill);
        }

        // POST: WindMills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WindMillID,WindMillName,CreatedOn,ModifiedOn,CreatedBy,ModifiedBy,ManufacturerName,Latitude,Longtitude,WindParkID")] WindMill windMill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(windMill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WindParkID = new SelectList(db.WindPark, "WindParkID", "WindParkName", windMill.WindParkID);
            return View(windMill);
        }

        // GET: WindMills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindMill windMill = db.WindMill.Find(id);
            if (windMill == null)
            {
                return HttpNotFound();
            }
            return View(windMill);
        }

        // POST: WindMills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WindMill windMill = db.WindMill.Find(id);
            db.WindMill.Remove(windMill);
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
