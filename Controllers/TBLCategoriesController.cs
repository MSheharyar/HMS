using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMS_Project.Models;

namespace HMS_Project.Controllers
{
    public class TBLCategoriesController : Controller
    {
        private DBHMSEntities db = new DBHMSEntities();

        // GET: TBLCategories
        public ActionResult Index()
        {
            return View(db.TBLCategories.ToList());
        }

        // GET: TBLCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLCategory tBLCategory = db.TBLCategories.Find(id);
            if (tBLCategory == null)
            {
                return HttpNotFound();
            }
            return View(tBLCategory);
        }

        // GET: TBLCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBLCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cat_Name, Remarks")] TBLCategory tBLCategory)
        {
            if (ModelState.IsValid)
            {
                db.TBLCategories.Add(tBLCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBLCategory);
        }

        // GET: TBLCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLCategory tBLCategory = db.TBLCategories.Find(id);
            if (tBLCategory == null)
            {
                return HttpNotFound();
            }
            return View(tBLCategory);
        }

        // POST: TBLCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cat_Name, Remarks")] TBLCategory tBLCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBLCategory);
        }

        // GET: TBLCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLCategory tBLCategory = db.TBLCategories.Find(id);
            if (tBLCategory == null)
            {
                return HttpNotFound();
            }
            return View(tBLCategory);
        }

        // POST: TBLCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLCategory tBLCategory = db.TBLCategories.Find(id);
            db.TBLCategories.Remove(tBLCategory);
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
