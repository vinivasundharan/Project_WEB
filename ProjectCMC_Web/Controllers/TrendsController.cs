using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Excel;
//using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using ProjectCMC_Web.DAL;
using ProjectCMC_Web.Models;

namespace ProjectCMC_Web.Controllers
{
    public class TrendsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Trends
        public ActionResult Index()
        {
            var trend = db.Trend.Include(t => t.Node);
            return View(trend.ToList());
        }

        // GET: Trends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trend trend = db.Trend.Find(id);
            if (trend == null)
            {
                return HttpNotFound();
            }
            return View(trend);
        }

        // GET: Trends/Create
        public ActionResult Create()
        {
            ViewBag.NodeID = new SelectList(db.Node, "NodeID", "NodeName");
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    Stream stream = upload.InputStream;

                    // We return the interface, so that
                    IExcelDataReader reader = null;
                    if (upload.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        // upload.SaveAs(Server.MapPath("/App_Data/Excel Files/" + upload.FileName));
                    }
                    else if (upload.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        //string filepath = Server.MapPath("/App_Data/Excel Files/" + upload.FileName);
                        //upload.SaveAs(filepath);
                        //ImportExcel(filepath);                        
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }

                    DataSet result = reader.AsDataSet();
                    reader.Close();

                    DataTable dt = result.Tables[0];
                    bool flag = true;

                }
                
            }
            return View();
        }


        // POST: Trends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrendID,ReadingTime,F1Amp,F2Amp,F3Amp,F4Amp,F5Amp,F1Phase,F2Phase,F3Phase,F4Phase,F5Phase,F1HA,F2HA,F3HA,F4HA,F5HA,F1HW,F2HW,F3HW,F4HW,F5HW,F1Status,F2Status,F3Status,F4Status,F5Status,Speed,Process,Digital,StorageReason,BOV,NodeID")] Trend trend)
        {
            if (ModelState.IsValid)
            {
                db.Trend.Add(trend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NodeID = new SelectList(db.Node, "NodeID", "NodeName", trend.NodeID);
            return View(trend);
        }

        // GET: Trends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trend trend = db.Trend.Find(id);
            if (trend == null)
            {
                return HttpNotFound();
            }
            ViewBag.NodeID = new SelectList(db.Node, "NodeID", "NodeName", trend.NodeID);
            return View(trend);
        }

        // POST: Trends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrendID,ReadingTime,F1Amp,F2Amp,F3Amp,F4Amp,F5Amp,F1Phase,F2Phase,F3Phase,F4Phase,F5Phase,F1HA,F2HA,F3HA,F4HA,F5HA,F1HW,F2HW,F3HW,F4HW,F5HW,F1Status,F2Status,F3Status,F4Status,F5Status,Speed,Process,Digital,StorageReason,BOV,NodeID")] Trend trend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NodeID = new SelectList(db.Node, "NodeID", "NodeName", trend.NodeID);
            return View(trend);
        }

        // GET: Trends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trend trend = db.Trend.Find(id);
            if (trend == null)
            {
                return HttpNotFound();
            }
            return View(trend);
        }

        // POST: Trends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trend trend = db.Trend.Find(id);
            db.Trend.Remove(trend);
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
