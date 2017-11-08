using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gazorpgazorpfridge.Models;

namespace Gazorpgazorpfridge.Controllers
{
    public class RefrigeradorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Refrigeradors
        public ActionResult Index()
        {
            return View(db.Refrigeradors.ToList());
        }

        // GET: Refrigeradors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador refrigerador = db.Refrigeradors.Find(id);
            if (refrigerador == null)
            {
                return HttpNotFound();
            }
            return View(refrigerador);
        }

        // GET: Refrigeradors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Refrigeradors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,capacidad,indiceDeEnfriamento")] Refrigerador refrigerador)
        {
            if (ModelState.IsValid)
            {
                db.Refrigeradors.Add(refrigerador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(refrigerador);
        }

        // GET: Refrigeradors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador refrigerador = db.Refrigeradors.Find(id);
            if (refrigerador == null)
            {
                return HttpNotFound();
            }
            return View(refrigerador);
        }

        // POST: Refrigeradors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,capacidad,indiceDeEnfriamento")] Refrigerador refrigerador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refrigerador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refrigerador);
        }

        // GET: Refrigeradors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador refrigerador = db.Refrigeradors.Find(id);
            if (refrigerador == null)
            {
                return HttpNotFound();
            }
            return View(refrigerador);
        }

        // POST: Refrigeradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Refrigerador refrigerador = db.Refrigeradors.Find(id);
            db.Refrigeradors.Remove(refrigerador);
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
