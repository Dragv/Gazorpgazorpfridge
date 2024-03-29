﻿using System;
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
    public class CanastaBasicaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CanastaBasicas
        public ActionResult Index(int? id)
        {
            var canasta = db.CanastasBasicas.Where(u => u.id == id).FirstOrDefault();
            return View(canasta);
        }

        // GET: CanastaBasicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanastaBasica canastaBasica = db.CanastasBasicas.Find(id);
            if (canastaBasica == null)
            {
                return HttpNotFound();
            }
            return View(canastaBasica);
        }

        // GET: CanastaBasicas/Create
        public ActionResult Create(int? id)
        {
            ViewBag.refri = db.Refrigeradores.Find(id);
            return View();
        }

        // POST: CanastaBasicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,perEscasez,refriId")] CanastaBasica canastaBasica)
        {
            if (ModelState.IsValid)
            {
                //db.Refrigeradores.Where(u => u.id == refid).FirstOrDefault().micanasta = canastaBasica;
                db.CanastasBasicas.Add(canastaBasica);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(canastaBasica);
        }

        // GET: CanastaBasicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanastaBasica canastaBasica = db.CanastasBasicas.Find(id);
            if (canastaBasica == null)
            {
                return HttpNotFound();
            }
            return View(canastaBasica);
        }

        // POST: CanastaBasicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,perEscasez,refriId")] CanastaBasica canastaBasica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canastaBasica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(canastaBasica);
        }

        // GET: CanastaBasicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanastaBasica canastaBasica = db.CanastasBasicas.Find(id);
            if (canastaBasica == null)
            {
                return HttpNotFound();
            }
            return View(canastaBasica);
        }

        // POST: CanastaBasicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CanastaBasica canastaBasica = db.CanastasBasicas.Find(id);
            db.CanastasBasicas.Remove(canastaBasica);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
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
