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
using System.Net.Mail;

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
            var canastaBasica = db.CanastasBasicas.Where(u => u.refriId == refrigerador.id).FirstOrDefault();
            var paquetes = db.Paquetes.Where(u => u.refriId == refrigerador.id).ToList();
            ICollection<String> productosAcabados = new List<String>();
            if (canastaBasica != null)
            {

                foreach (var item in canastaBasica.productForCanasta)
                {
                    var total = 0;
                    foreach (var pro in paquetes)
                    {
                        if (item.productoId == pro.productId)
                        {
                            total += pro.cantidad;
                        }
                    }
                    if (total <= item.CantidadMaxima*canastaBasica.perEscasez)
                    {
                        productosAcabados.Add(item.Producto.nombre);      
                    }
                }

                if (productosAcabados.Count > 0)
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("gazorpgazor@gmail.com");
                    string currentUserId = User.Identity.GetUserId();
                    ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                    mailMessage.To.Add("geratrex781@gmail.com");
                    mailMessage.Subject = $"Se esta acabando los productos siguientes de tu canasta basica";
                    mailMessage.Body = $"Se estan acabando los productos {productosAcabados.ToString()}";

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("gazorpgazor", "Hermes_69");

                    smtp.Send(mailMessage);
                }
            }

            var toReturn = new RefriDetailsViewModel
            {
                refrigerador = refrigerador,
                canastaBasica = canastaBasica
            };
            if (refrigerador == null)
            {
                return HttpNotFound();
            }
            return View(toReturn);
        }

        // GET: Refrigeradores/Details/5
        public ActionResult ListPaquetes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lista = db.Refrigeradores.Where(u => u.id == id).FirstOrDefault().paquetes.ToList();
            return View(lista);
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
                refrigerador.capacidad_restante = frModel.capacidad;
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
