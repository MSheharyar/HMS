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
    public class TBLBookingsController : Controller
    {
        private DBHMSEntities db = new DBHMSEntities();

        // GET: TBLBookings
        public ActionResult Index()
        {
            var tBLBookings = db.TBLBookings.Include(t => t.TBLUser).Include(t => t.TBLRoom);
            return View(tBLBookings.ToList());
        }

        // GET: TBLBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLBooking tBLBooking = db.TBLBookings.Find(id);
            if (tBLBooking == null)
            {
                return HttpNotFound();
            }
            return View(tBLBooking);
        }

        // GET: TBLBookings/Create
        public ActionResult Create()
        {
            ViewBag.Agent = new SelectList(db.TBLUsers, "ID", "User_Name");
            ViewBag.BRoom = new SelectList(db.TBLRooms, "ID", "Room_Name");
            return View();
        }

        // POST: TBLBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BDate,BRoom,Agent,DateIn,DateOut,Amount")] TBLBooking tBLBooking)
        {
            if (ModelState.IsValid)
            {
                db.TBLBookings.Add(tBLBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Agent = new SelectList(db.TBLUsers, "ID", "User_Name", tBLBooking.Agent);
            ViewBag.BRoom = new SelectList(db.TBLRooms, "ID", "Room_Name", tBLBooking.BRoom);
            return View(tBLBooking);
        }

        // GET: TBLBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLBooking tBLBooking = db.TBLBookings.Find(id);
            if (tBLBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Agent = new SelectList(db.TBLUsers, "ID", "User_Name", tBLBooking.Agent);
            ViewBag.BRoom = new SelectList(db.TBLRooms, "ID", "Room_Name", tBLBooking.BRoom);
            return View(tBLBooking);
        }

        // POST: TBLBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BDate,BRoom,Agent,DateIn,DateOut,Amount")] TBLBooking tBLBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Agent = new SelectList(db.TBLUsers, "ID", "User_Name", tBLBooking.Agent);
            ViewBag.BRoom = new SelectList(db.TBLRooms, "ID", "Room_Name", tBLBooking.BRoom);
            return View(tBLBooking);
        }

        // GET: TBLBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLBooking tBLBooking = db.TBLBookings.Find(id);
            if (tBLBooking == null)
            {
                return HttpNotFound();
            }
            return View(tBLBooking);
        }

        // POST: TBLBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLBooking tBLBooking = db.TBLBookings.Find(id);
            db.TBLBookings.Remove(tBLBooking);
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
