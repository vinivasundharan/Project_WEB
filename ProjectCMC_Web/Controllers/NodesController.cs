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
    public class NodesController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Nodes
        public ActionResult Index()
        {
            var node = db.Node.Include(n => n.WindMill);
            return View(node.ToList());
        }

        // GET: Nodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = db.Node.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // GET: Nodes/Create
        public ActionResult Create()
        {
            ViewBag.WindMillID = new SelectList(db.WindMill, "WindMillID", "WindMillName");
            return View();
        }

        // POST: Nodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NodeID,NodeName,NodeDescription,CreatedOn,ModifiedOn,CreatedBy,ModifiedBy,WindMillID")] Node node)
        {
            if (ModelState.IsValid)
            {
                node.CreatedBy = User.Identity.Name;
                node.CreatedOn = DateTime.Now;
                node.ModifiedBy = User.Identity.Name;
                node.ModifiedOn = DateTime.Now;
                db.Node.Add(node);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WindMillID = new SelectList(db.WindMill, "WindMillID", "WindMillName", node.WindMillID);
            return View(node);
        }

        public ActionResult ViewTrend(int id)
        {
            var trendlist = db.Trend.Where(x => x.NodeID == id).ToList();
            return View(trendlist);
        }

        // GET: Nodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = db.Node.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            ViewBag.WindMillID = new SelectList(db.WindMill, "WindMillID", "WindMillName", node.WindMillID);
            return View(node);
        }

        // POST: Nodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NodeID,NodeName,NodeDescription,CreatedOn,ModifiedOn,CreatedBy,ModifiedBy,WindMillID")] Node node)
        {
            if (ModelState.IsValid)
            {
                db.Entry(node).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WindMillID = new SelectList(db.WindMill, "WindMillID", "WindMillName", node.WindMillID);
            return View(node);
        }

        // GET: Nodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Node node = db.Node.Find(id);
            if (node == null)
            {
                return HttpNotFound();
            }
            return View(node);
        }

        // POST: Nodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Node node = db.Node.Find(id);
            db.Node.Remove(node);
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
