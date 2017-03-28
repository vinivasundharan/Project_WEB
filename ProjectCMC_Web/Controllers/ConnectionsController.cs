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
    public class ConnectionsController : Controller
    {
        //fdgdfgdfhfdhdf
        private ProjectContext db = new ProjectContext();

        // GET: Connections
        public ActionResult Index()
        {
            var connection = db.Connection.Include(c => c.WindMill);
            return View(connection.ToList());
        }

        // GET: Connections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connection connection = db.Connection.Find(id);
            if (connection == null)
            {
                return HttpNotFound();
            }
            return View(connection);
        }

        // GET: Connections/Create
        public ActionResult Create()
        {
            ViewBag.WindMillID = new SelectList(db.WindMill, "WindMillID", "WindMillName");
            return View();
        }

        // POST: Connections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConnectionID,StartTime,EndTime,LastIP,ConnectionStatus,WindMillID")] Connection connection)
        {
            if (ModelState.IsValid)
            {
                db.Connection.Add(connection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WindMillID = new SelectList(db.WindMill, "WindMillID", "WindMillName", connection.WindMillID);
            return View(connection);
        }

        // GET: Connections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connection connection = db.Connection.Find(id);
            if (connection == null)
            {
                return HttpNotFound();
            }
            ViewBag.WindMillID = new SelectList(db.WindMill, "WindMillID", "WindMillName", connection.WindMillID);
            return View(connection);
        }

        // POST: Connections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConnectionID,StartTime,EndTime,LastIP,ConnectionStatus,WindMillID")] Connection connection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(connection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WindMillID = new SelectList(db.WindMill, "WindMillID", "WindMillName", connection.WindMillID);
            return View(connection);
        }

        // GET: Connections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Connection connection = db.Connection.Find(id);
            if (connection == null)
            {
                return HttpNotFound();
            }
            return View(connection);
        }

        // POST: Connections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Connection connection = db.Connection.Find(id);
            db.Connection.Remove(connection);
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
