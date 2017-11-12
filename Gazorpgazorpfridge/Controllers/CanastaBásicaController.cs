using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gazorpgazorpfridge.Controllers
{
    public class CanastaBasicaController : Controller
    {
        // GET: CanastaBásica
        public ActionResult Index()
        {
            return View();
        }

        // GET: CanastaBásica/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CanastaBásica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CanastaBásica/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CanastaBásica/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CanastaBásica/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CanastaBásica/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CanastaBásica/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
