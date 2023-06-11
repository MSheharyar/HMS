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
    public class TBLUsersController : Controller
    {
        private DBHMSEntities db = new DBHMSEntities();

        // GET: TBLUsers
        public ActionResult Index()
        {
            return View(db.TBLUsers.ToList());
        }

        // GET: TBLUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUser tBLUser = db.TBLUsers.Find(id);
            if (tBLUser == null)
            {
                return HttpNotFound();
            }
            return View(tBLUser);
        }

        // GET: TBLUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBLUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,User_Name,User_Phone,User_Gender,User_Address,User_Password")] TBLUser tBLUser)
        {
            if (ModelState.IsValid)
            {
                db.TBLUsers.Add(tBLUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBLUser);
        }

        // GET: TBLUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUser tBLUser = db.TBLUsers.Find(id);
            if (tBLUser == null)
            {
                return HttpNotFound();
            }
            return View(tBLUser);
        }

        // POST: TBLUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,User_Name,User_Phone,User_Gender,User_Address,User_Password")] TBLUser tBLUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBLUser);
        }

        // GET: TBLUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUser tBLUser = db.TBLUsers.Find(id);
            if (tBLUser == null)
            {
                return HttpNotFound();
            }
            return View(tBLUser);
        }

        // POST: TBLUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLUser tBLUser = db.TBLUsers.Find(id);
            db.TBLUsers.Remove(tBLUser);
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
