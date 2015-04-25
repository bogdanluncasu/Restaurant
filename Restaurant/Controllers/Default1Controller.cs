using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class Default1Controller : Controller
    {
        private RestaurantDataContext db = new RestaurantDataContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.MeniuClients.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            MeniuClient meniuclient = db.MeniuClients.Find(id);
            if (meniuclient == null)
            {
                return HttpNotFound();
            }
            return View(meniuclient);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeniuClient meniuclient)
        {
            if (ModelState.IsValid)
            {
                db.MeniuClients.Add(meniuclient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meniuclient);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MeniuClient meniuclient = db.MeniuClients.Find(id);
            if (meniuclient == null)
            {
                return HttpNotFound();
            }
            return View(meniuclient);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MeniuClient meniuclient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meniuclient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meniuclient);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MeniuClient meniuclient = db.MeniuClients.Find(id);
            if (meniuclient == null)
            {
                return HttpNotFound();
            }
            return View(meniuclient);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeniuClient meniuclient = db.MeniuClients.Find(id);
            db.MeniuClients.Remove(meniuclient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}