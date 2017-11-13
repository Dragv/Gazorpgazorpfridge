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
    public class ProductForRecetasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductForRecetas
        public ActionResult Index()
        {
            var productForRecetas = db.ProductForRecetas.Include(p => p.Producto).Include(p => p.Receta);
            return View(productForRecetas.ToList());
        }

        // GET: ProductForRecetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductForReceta productForReceta = db.ProductForRecetas.Find(id);
            if (productForReceta == null)
            {
                return HttpNotFound();
            }
            return View(productForReceta);
        }

        // GET: ProductForRecetas/Create
        public ActionResult Create()
        {
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo");
            ViewBag.recetaId = new SelectList(db.Recetas, "id", "descripcion");
            return View();
        }

        // POST: ProductForRecetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,recetaId,productoId")] ProductForReceta productForReceta)
        {
            if (ModelState.IsValid)
            {
                db.ProductForRecetas.Add(productForReceta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo", productForReceta.productoId);
            ViewBag.recetaId = new SelectList(db.Recetas, "id", "descripcion", productForReceta.recetaId);
            return View(productForReceta);
        }

        public ActionResult CreateForReceta(int? id)
        {
            ViewBag.receta = db.Recetas.Find(id);
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo");
            ViewBag.recetaId = new SelectList(db.Recetas, "id", "descripcion");
            return View();
        }

        // POST: ProductForRecetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForReceta([Bind(Include = "id,recetaId,productoId")] ProductForReceta productForReceta)
        {
            if (ModelState.IsValid)
            {
                db.ProductForRecetas.Add(productForReceta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo", productForReceta.productoId);
            ViewBag.recetaId = new SelectList(db.Recetas, "id", "descripcion", productForReceta.recetaId);
            return View(productForReceta);
        }

        // GET: ProductForRecetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductForReceta productForReceta = db.ProductForRecetas.Find(id);
            if (productForReceta == null)
            {
                return HttpNotFound();
            }
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo", productForReceta.productoId);
            ViewBag.recetaId = new SelectList(db.Recetas, "id", "descripcion", productForReceta.recetaId);
            return View(productForReceta);
        }

        // POST: ProductForRecetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,recetaId,productoId")] ProductForReceta productForReceta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productForReceta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productoId = new SelectList(db.Productos, "id", "codigo", productForReceta.productoId);
            ViewBag.recetaId = new SelectList(db.Recetas, "id", "descripcion", productForReceta.recetaId);
            return View(productForReceta);
        }

        // GET: ProductForRecetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductForReceta productForReceta = db.ProductForRecetas.Find(id);
            if (productForReceta == null)
            {
                return HttpNotFound();
            }
            return View(productForReceta);
        }

        // POST: ProductForRecetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductForReceta productForReceta = db.ProductForRecetas.Find(id);
            db.ProductForRecetas.Remove(productForReceta);
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
