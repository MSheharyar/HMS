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
    public class TBLRoomsController : Controller
    {
        private DBHMSEntities db = new DBHMSEntities();

        // GET: TBLRooms
        public ActionResult Index()
        {
            var tBLRooms = db.TBLRooms.Include(t => t.TBLCategory);
            return View(tBLRooms.ToList());
        }

        // GET: TBLRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRoom tBLRoom = db.TBLRooms.Find(id);
            if (tBLRoom == null)
            {
                return HttpNotFound();
            }
            return View(tBLRoom);
        }

        // GET: TBLRooms/Create
        public ActionResult Create()
        {
            ViewBag.RoomCat = new SelectList(db.TBLCategories, "ID", "Cat_Name");
            return View();
        }

        // POST: TBLRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Room_Name,RoomCat,Location,Cost,Remarks,Status")] TBLRoom tBLRoom)
        {
            if (ModelState.IsValid)
            {
                db.TBLRooms.Add(tBLRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomCat = new SelectList(db.TBLCategories, "ID", "Cat_Name", tBLRoom.RoomCat);
            return View(tBLRoom);
        }

        // GET: TBLRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRoom tBLRoom = db.TBLRooms.Find(id);
            if (tBLRoom == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomCat = new SelectList(db.TBLCategories, "ID", "Cat_Name", tBLRoom.RoomCat);
            return View(tBLRoom);
        }

        // POST: TBLRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Room_Name,RoomCat,Location,Cost,Remarks,Status")] TBLRoom tBLRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomCat = new SelectList(db.TBLCategories, "ID", "Cat_Name", tBLRoom.RoomCat);
            return View(tBLRoom);
        }

        // GET: TBLRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRoom tBLRoom = db.TBLRooms.Find(id);
            if (tBLRoom == null)
            {
                return HttpNotFound();
            }
            return View(tBLRoom);
        }

        // POST: TBLRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLRoom tBLRoom = db.TBLRooms.Find(id);
            db.TBLRooms.Remove(tBLRoom);
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
