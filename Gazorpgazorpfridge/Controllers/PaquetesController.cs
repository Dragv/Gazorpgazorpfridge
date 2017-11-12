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
    public class PaquetesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Paquetes
        public ActionResult Index(int? id)
        {
            var paquetes = db.Paquetes.Include(p => p.Producto).Include(p => p.Refrigerador);
            if (id != null) {
                paquetes = db.Paquetes.Where(u => u.refriId == id).Include(p => p.Producto).Include(p => p.Refrigerador);
            }
            return View(paquetes.ToList());
        }

        // GET: Paquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = db.Paquetes.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // GET: Paquetes/Create
        public ActionResult CreateForRefri(int? id)
        {
            ViewBag.refri = db.Refrigeradores.Where(u => u.id == id).FirstOrDefault();
            ViewBag.productId = new SelectList(db.Productos, "id", "codigo");
            ViewBag.refriId = new SelectList(db.Refrigeradores, "id", "codigo");
            return View();
        }

        // POST: Paquetes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForRefri([Bind(Include = "id,cantidad,caducidad,refriId,productId")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                db.Paquetes.Add(paquete);
                var current_refri = db.Refrigeradores.Where(u => u.id == paquete.refriId).FirstOrDefault();
                var current_vol_pack = db.Productos.Where(u => u.id == paquete.productId).FirstOrDefault();
                var volumen_consumido = paquete.cantidad * current_vol_pack.espacioVol;

                if (current_refri.capacidad_restante - volumen_consumido < 0)
                {
                    TempData["ErrorMessage"] = "Capacidad excedida de refrigerador, no se pudo agregar su producto";
                    return RedirectToAction("Index", "Home");
                }
                current_refri.capacidad_restante -= volumen_consumido;

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.productId = new SelectList(db.Productos, "id", "codigo", paquete.productId);
            ViewBag.refriId = new SelectList(db.Refrigeradores, "id", "codigo", paquete.refriId);
            return View(paquete);
        }

        // GET: Paquetes/Create
        public ActionResult Create()
        {
            ViewBag.productId = new SelectList(db.Productos, "id", "codigo");
            ViewBag.refriId = new SelectList(db.Refrigeradores, "id", "codigo");
            return View();
        }

        // POST: Paquetes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cantidad,caducidad,refriId,productId")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                db.Paquetes.Add(paquete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.Productos, "id", "codigo", paquete.productId);
            ViewBag.refriId = new SelectList(db.Refrigeradores, "id", "codigo", paquete.refriId);
            return View(paquete);
        }

        // GET: Paquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = db.Paquetes.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.productId = new SelectList(db.Productos, "id", "codigo", paquete.productId);
            ViewBag.refriId = new SelectList(db.Refrigeradores, "id", "codigo", paquete.refriId);
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cantidad,caducidad,refriId,productId")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                var pack = db.Paquetes.Where(u => u.id == paquete.id).FirstOrDefault();
                
                var current_refri = db.Refrigeradores.Where(u => u.id == pack.refriId).FirstOrDefault();

                var current_product = db.Productos.Where(u => u.id == pack.productId).FirstOrDefault();

                pack.cantidad -= paquete.cantidad;

                if (pack.cantidad <= 0)
                {
                    current_refri.capacidad_restante += (paquete.cantidad + pack.cantidad) * current_product.espacioVol;
                    db.Paquetes.Remove(pack);
                }
                else
                {
                    current_refri.capacidad_restante += paquete.cantidad * current_product.espacioVol;
                }

                //db.Entry(paquete).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.productId = new SelectList(db.Productos, "id", "codigo", paquete.productId);
            ViewBag.refriId = new SelectList(db.Refrigeradores, "id", "codigo", paquete.refriId);
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paquete paquete = db.Paquetes.Find(id);
            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paquete paquete = db.Paquetes.Find(id);
            db.Paquetes.Remove(paquete);
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
