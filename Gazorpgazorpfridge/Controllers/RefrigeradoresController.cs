using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gazorpgazorpfridge.Models;
using Microsoft.AspNet.Identity;

namespace Gazorpgazorpfridge.Controllers
{
    [Authorize(Roles = "User")]
    public class RefrigeradoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Refrigeradores
        public ActionResult Index()
        {
            var refrigeradores = db.Refrigeradores.Include(r => r.Modelo);
            return RedirectToAction("Index", "Home/Index");
            //return View(refrigeradores.ToList());
        }

        // GET: Refrigeradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador refrigerador = db.Refrigeradores.Find(id);
            if (refrigerador == null)
            {
                return HttpNotFound();
            }
            return View(refrigerador);
        }

        // GET: Refrigeradores/Create
        public ActionResult Create()
        {
            //ViewBag.modeloId = new SelectList(db.Modelos, "id", "codigo");
            return View();
        }

        // POST: Refrigeradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo")] Refrigerador refrigerador)
        {
            // Find respective model
            var frModel = db.Modelos.Where(u => u.codigo == refrigerador.codigo).FirstOrDefault();

            if (ModelState.IsValid)
            {
                // Fill the new refri atributes
                refrigerador.applicationUser_id = User.Identity.GetUserId();
                refrigerador.modeloId = frModel.id;
                refrigerador.paquetes = new List<Paquete>();
                // Update the database
                db.Refrigeradores.Add(refrigerador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.modeloId = new SelectList(db.Modelos, "id", "codigo", refrigerador.modeloId);
            return View(refrigerador);
        }

        // GET: Refrigeradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador refrigerador = db.Refrigeradores.Find(id);
            if (refrigerador == null)
            {
                return HttpNotFound();
            }
            ViewBag.modeloId = new SelectList(db.Modelos, "id", "codigo", refrigerador.modeloId);
            return View(refrigerador);
        }

        // POST: Refrigeradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,modeloId")] Refrigerador refrigerador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refrigerador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.modeloId = new SelectList(db.Modelos, "id", "codigo", refrigerador.modeloId);
            return View(refrigerador);
        }

        // GET: Refrigeradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refrigerador refrigerador = db.Refrigeradores.Find(id);
            if (refrigerador == null)
            {
                return HttpNotFound();
            }
            return View(refrigerador);
        }

        // POST: Refrigeradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Refrigerador refrigerador = db.Refrigeradores.Find(id);
            db.Refrigeradores.Remove(refrigerador);
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
