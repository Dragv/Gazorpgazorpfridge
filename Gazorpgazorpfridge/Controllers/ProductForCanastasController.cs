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
    public class ProductForCanastasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductForCanastas
        public ActionResult Index()
        {
            var productForCanastas = db.ProductForCanastas.Include(p => p.CanastaBasica).Include(p => p.Producto);
            return View(productForCanastas.ToList());
        }

        // GET: ProductForCanastas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductForCanasta productForCanasta = db.ProductForCanastas.Find(id);
            if (productForCanasta == null)
            {
                return HttpNotFound();
            }
            return View(productForCanasta);
        }

        // GET: ProductForCanastas/Create
        public ActionResult Create()
        {
            ViewBag.canastaId = new SelectList(db.CanastasBasicas, "id", "descripcion");
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo");
            return View();
        }

        // POST: ProductForCanastas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,canastaId,productoId")] ProductForCanasta productForCanasta)
        {
            if (ModelState.IsValid)
            {
                db.ProductForCanastas.Add(productForCanasta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.canastaId = new SelectList(db.CanastasBasicas, "id", "descripcion", productForCanasta.canastaId);
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo", productForCanasta.productoId);
            return View(productForCanasta);
        }

        public ActionResult CreateForCanasta(int? id)
        {
            ViewBag.canasta = db.CanastasBasicas.Find(id);
            ViewBag.canastaId = new SelectList(db.CanastasBasicas, "id", "descripcion");
            ViewBag.productoId = new SelectList(db.Productos, "id", "nombre");
            return View();
        }

        // POST: ProductForCanastas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForCanasta([Bind(Include = "id,canastaId,productoId")] ProductForCanasta productForCanasta)
        {
            if (ModelState.IsValid)
            {
                db.ProductForCanastas.Add(productForCanasta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.canastaId = new SelectList(db.CanastasBasicas, "id", "descripcion", productForCanasta.canastaId);
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo", productForCanasta.productoId);
            return View(productForCanasta);
        }

        // GET: ProductForCanastas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductForCanasta productForCanasta = db.ProductForCanastas.Find(id);
            if (productForCanasta == null)
            {
                return HttpNotFound();
            }
            ViewBag.canastaId = new SelectList(db.CanastasBasicas, "id", "descripcion", productForCanasta.canastaId);
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo", productForCanasta.productoId);
            return View(productForCanasta);
        }

        // POST: ProductForCanastas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,canastaId,productoId")] ProductForCanasta productForCanasta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productForCanasta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.canastaId = new SelectList(db.CanastasBasicas, "id", "descripcion", productForCanasta.canastaId);
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo", productForCanasta.productoId);
            return View(productForCanasta);
        }

        // GET: ProductForCanastas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductForCanasta productForCanasta = db.ProductForCanastas.Find(id);
            if (productForCanasta == null)
            {
                return HttpNotFound();
            }
            return View(productForCanasta);
        }

        // POST: ProductForCanastas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductForCanasta productForCanasta = db.ProductForCanastas.Find(id);
            db.ProductForCanastas.Remove(productForCanasta);
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
