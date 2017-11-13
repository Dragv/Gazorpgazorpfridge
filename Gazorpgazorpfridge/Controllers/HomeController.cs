using Gazorpgazorpfridge.Models;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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