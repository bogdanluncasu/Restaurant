﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ChelnerController : Controller
    {
        private RestaurantDataContext db = new RestaurantDataContext();

        //
        // GET: /Chelner/

        public ActionResult Index()
        {
            return View(db.Chelners.ToList());
        }

        //
        // GET: /Chelner/Details/5

        public ActionResult Details(int id = 0)
        {
            Chelner chelner = db.Chelners.Find(id);
            if (chelner == null)
            {
                return HttpNotFound();
            }
            return View(chelner);
        }

        //
        // GET: /Chelner/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Chelner/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chelner chelner)
        {
            if (ModelState.IsValid)
            {
                db.Chelners.Add(chelner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chelner);
        }

        //
        // GET: /Chelner/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Chelner chelner = db.Chelners.Find(id);
            if (chelner == null)
            {
                return HttpNotFound();
            }
            return View(chelner);
        }

        //
        // POST: /Chelner/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chelner chelner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chelner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chelner);
        }

        //
        // GET: /Chelner/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Chelner chelner = db.Chelners.Find(id);
            if (chelner == null)
            {
                return HttpNotFound();
            }
            return View(chelner);
        }

        //
        // POST: /Chelner/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chelner chelner = db.Chelners.Find(id);
            db.Chelners.Remove(chelner);
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