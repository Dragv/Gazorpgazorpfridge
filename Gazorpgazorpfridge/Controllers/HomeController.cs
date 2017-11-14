using Gazorpgazorpfridge.Models;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace Gazorpgazorpfridge.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var toReturn = new AdminViewModel
                {
                    modelos = db.Modelos.ToList(),
                    productos = db.Productos.ToList()
                };
                return View(toReturn);
            }
            else
            {
                var userID = User.Identity.GetUserId();
                var refrigeradores = db.Refrigeradores.Where(u => u.applicationUser_id == userID).ToList();
                var recetas = db.Recetas.Where(u => u.applicationUser_id == userID).ToList();
                var toReturn = new UserViewModel
                {
                    refrigeradores = refrigeradores,
                    recetas = recetas
                };
                ViewBag.errMsg = TempData["ErrorMessage"] as string;

                // Check recetas availability
                if (refrigeradores.Count > 0 && recetas.Count > 0)
                {
                    // Init dictionary
                    Dictionary<int, bool> recetas_disp = new Dictionary<int, bool>();
                    // Init productos globales
                    ICollection<int> produc_disp = new List<int>();
                    // Iterate over Refris
                    foreach (var refri in refrigeradores)
                    {
                        var packs_refri = db.Paquetes.Where(u => u.refriId == refri.id).ToList();
                        if (packs_refri != null)
                        {
                            foreach (var pack in packs_refri)
                            {
                                if (!produc_disp.Contains(pack.productId))
                                {
                                    produc_disp.Add(pack.productId);
                                }
                            }
                        }
                    }
                    // Iterate over Recetas
                    foreach (var rec in recetas)
                    {
                        bool complete = false;
                        foreach (var product in rec.productosForReceta)
                        {
                            if (produc_disp.Contains(product.productoId))
                            {
                                complete = true;
                            }
                            else
                            {
                                complete = false;
                                break;
                            }
                        }
                        recetas_disp.Add(rec.id, complete);
                    }
                    ViewBag.rece_disp = recetas_disp;
                }
                // Check recetas availability end

                foreach (var item in refrigeradores)
                {
                    foreach (var pack in db.Paquetes.Where(u => u.refriId == item.id).ToList())
                    {
                        if (pack.caducidad < System.DateTime.Now)
                        {
                            MailMessage mailMessage = new MailMessage();
                            mailMessage.From = new MailAddress("gazorpgazor@gmail.com");
                            string currentUserId = User.Identity.GetUserId();
                            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
                            mailMessage.To.Add(currentUser.Email);
                            mailMessage.Subject = $"Se caduco un producto de tu refri {item.codigo}";
                            mailMessage.Body = $"Se caduco el productp {pack.Producto.nombre}, el dia {pack.caducidad}";

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
                }

                if(toReturn != null)
                {
                    return View(toReturn);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "A virtual Smart Fridge simulator that will help you to organize your food.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}