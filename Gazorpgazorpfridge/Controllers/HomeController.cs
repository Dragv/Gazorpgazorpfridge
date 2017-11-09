using Gazorpgazorpfridge.Models;
using System;
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
            var toReturn = new AdminViewModel
            {
                modelos = db.Modelos.ToList(),
                productos = db.Productos.ToList()
            };
            return View(toReturn);
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