using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gazorpgazorpfridge.Controllers
{
    [Authorize(Roles = "User")]
    public class CanastaBasicaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CanastaBásica
        public ActionResult Index()
        {
            return View(db.CanastasBasicas.ToList());
        }

        // GET: CanastaBásica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanastaBasica canasta = db.CanastasBasicas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(canasta);
        }

        // GET: CanastaBásica/Create
        public ActionResult Create()
        {
            ViewBag.producto = db.Productos;
            ViewBag.productId = new SelectList(db.Productos, "id", "codigo");
            return View();
        }

        // POST: CanastaBásica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,perEscasez")] CanastaBasica canasta)
        {
           if (ModelState.IsValid)
            {
                db.CanastasBasicas.Add(canasta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(canasta);
        }

        // GET: CanastaBásica/Edit/5
        public ActionResult Edit(int? id)
        {
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanastaBasica canasta = db.CanastasBasicas.Find(id);
            if (canasta == null)
            {
                return HttpNotFound();
            }
            return View(canasta);
        }

        // POST: CanastaBásica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,perEscasez")] CanastaBasica canasta)
        {
             if (ModelState.IsValid)
            {
                db.Entry(canasta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(canasta);
        }

        // GET: CanastaBásica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanastaBasica canasta = db.CanastasBasicas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(canasta);
        }

        // POST: CanastaBásica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CanastaBasica canasta= db.CanastasBasicas.Find(id);
            db.CanastasBasicas.Remove(canasta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
