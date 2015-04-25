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
    public class HomeController : Controller
    {
        private RestaurantDataContext db = new RestaurantDataContext();

        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Chelner = new SelectList(db.Chelners, "Id", "ChelnerName");
            ViewBag.Comanda = new SelectList(db.MeniuClients, "Id", "Meniu");
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Client client)
        {
            Chelner someone = new Chelner();
            if (db.Chelners != null)
            {
                Random random = new Random();
                var mynr = random.Next(0, db.Chelners.Count());

                var firstOrDefault = db.Chelners.FirstOrDefault(x => x.Id == mynr);
                if (firstOrDefault != null)
                {
                    var chelnerName = firstOrDefault.ChelnerName;


                    someone.ChelnerName = chelnerName;
                    someone.Id = firstOrDefault.Id+1;
                    someone.Comanda = client.Comanda;
                    someone.Clients.FirstOrDefault(x => x.Chelner == someone.Id);
                    

                }

                client.Comanda = -1;
                client.Masa = -1;
                for (var i = 1; i <= 20; i++)
                {
                    if (db.Clients.Find(i) == null)
                    {
                        client.Masa = i;
                        break;
                    }
                }
                if (client.Masa == -1)
                {
                    ViewBag.ErrorMasa = "Toate mesele sunt ocupate.Va rugam reveniti mai tarziu";
                }
                if (ModelState.IsValid && client.Masa != -1)
                {
                    
                    db.Chelners.Add(someone);
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Chelner = new SelectList(db.Chelners, "Id", "ChelnerName", client.Chelner);
                ViewBag.Comanda = new SelectList(db.MeniuClients, "Id", "Meniu", client.Comanda);
            }
            return View(client);
        }

 
        public ActionResult Create()
        {
            ViewBag.Chelner = new SelectList(db.Chelners, "Id", "ChelnerName");
            ViewBag.Comanda = new SelectList(db.MeniuClients, "Id", "Meniu");
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Chelner = new SelectList(db.Chelners, "Id", "ChelnerName", client.Chelner);
            ViewBag.Comanda = new SelectList(db.MeniuClients, "Id", "Meniu", client.Comanda);
            return View(client);
        }
        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // GET: /Home/Create

 

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.Chelner = new SelectList(db.Chelners, "Id", "ChelnerName", client.Chelner);
            ViewBag.Comanda = new SelectList(db.MeniuClients, "Id", "Meniu", client.Comanda);
            return View(client);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Chelner = new SelectList(db.Chelners, "Id", "ChelnerName", client.Chelner);
            ViewBag.Comanda = new SelectList(db.MeniuClients, "Id", "Meniu", client.Comanda);
            return View(client);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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