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
    public class WindParksController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: WindParks
        public ActionResult Index()
        {
            return View(db.WindPark.ToList());
        }

        // GET: WindParks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindPark windPark = db.WindPark.Find(id);
            if (windPark == null)
            {
                return HttpNotFound();
            }
            return View(windPark);
        }

        // GET: WindParks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WindParks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WindParkID,WindParkName,CreatedOn,ModifiedOn,CreatedBy,ModifiedBy")] WindPark windPark)
        {
            if (ModelState.IsValid)
            {
                windPark.CreatedBy = User.Identity.Name;
                windPark.CreatedOn = DateTime.Now;
                windPark.ModifiedBy = User.Identity.Name;
                windPark.ModifiedOn = DateTime.Now;
                db.WindPark.Add(windPark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(windPark);
        }

        // GET: WindParks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindPark windPark = db.WindPark.Find(id);
            if (windPark == null)
            {
                return HttpNotFound();
            }
            return View(windPark);
        }

        // POST: WindParks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WindParkID,WindParkName,CreatedOn,ModifiedOn,CreatedBy,ModifiedBy")] WindPark windPark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(windPark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(windPark);
        }

        // GET: WindParks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindPark windPark = db.WindPark.Find(id);
            if (windPark == null)
            {
                return HttpNotFound();
            }
            return View(windPark);
        }

        // POST: WindParks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WindPark windPark = db.WindPark.Find(id);
            db.WindPark.Remove(windPark);
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
