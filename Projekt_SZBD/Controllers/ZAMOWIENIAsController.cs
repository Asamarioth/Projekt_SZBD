using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt_SZBD.Models;

namespace Projekt_SZBD.Controllers
{
    public class ZAMOWIENIAsController : Controller
    {
        private projektEntities db = new projektEntities();

        // GET: ZAMOWIENIAs
        public ActionResult Index()
        {
            var zAMOWIENIA = db.ZAMOWIENIA.Include(z => z.KLIENT).Include(z => z.PRACOWNIK);
            return View(zAMOWIENIA.ToList());
        }

        // GET: ZAMOWIENIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZAMOWIENIA zAMOWIENIA = db.ZAMOWIENIA.Find(id);
            if (zAMOWIENIA == null)
            {
                return HttpNotFound();
            }
            return View(zAMOWIENIA);
        }

        // GET: ZAMOWIENIAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Klienta = new SelectList(db.KLIENT, "ID_Klienta", "Nazwa");
            ViewBag.ID_Pracownika = new SelectList(db.PRACOWNIK, "ID_Pracownika", "Nazwisko");
            return View();
        }

        // POST: ZAMOWIENIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Zamowienia,Data_Zlozenia,ID_Klienta,ID_Pracownika")] ZAMOWIENIA zAMOWIENIA)
        {
            if (ModelState.IsValid)
            {
                db.ZAMOWIENIA.Add(zAMOWIENIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Klienta = new SelectList(db.KLIENT, "ID_Klienta", "Nazwa", zAMOWIENIA.ID_Klienta);
            ViewBag.ID_Pracownika = new SelectList(db.PRACOWNIK, "ID_Pracownika", "Nazwisko", zAMOWIENIA.ID_Pracownika);
            return View(zAMOWIENIA);
        }

        // GET: ZAMOWIENIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZAMOWIENIA zAMOWIENIA = db.ZAMOWIENIA.Find(id);
            if (zAMOWIENIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Klienta = new SelectList(db.KLIENT, "ID_Klienta", "Nazwa", zAMOWIENIA.ID_Klienta);
            ViewBag.ID_Pracownika = new SelectList(db.PRACOWNIK, "ID_Pracownika", "Nazwisko", zAMOWIENIA.ID_Pracownika);
            return View(zAMOWIENIA);
        }

        // POST: ZAMOWIENIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Zamowienia,Data_Zlozenia,ID_Klienta,ID_Pracownika")] ZAMOWIENIA zAMOWIENIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zAMOWIENIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Klienta = new SelectList(db.KLIENT, "ID_Klienta", "Nazwa", zAMOWIENIA.ID_Klienta);
            ViewBag.ID_Pracownika = new SelectList(db.PRACOWNIK, "ID_Pracownika", "Nazwisko", zAMOWIENIA.ID_Pracownika);
            return View(zAMOWIENIA);
        }

        // GET: ZAMOWIENIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZAMOWIENIA zAMOWIENIA = db.ZAMOWIENIA.Find(id);
            if (zAMOWIENIA == null)
            {
                return HttpNotFound();
            }
            return View(zAMOWIENIA);
        }

        // POST: ZAMOWIENIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZAMOWIENIA zAMOWIENIA = db.ZAMOWIENIA.Find(id);
            db.ZAMOWIENIA.Remove(zAMOWIENIA);
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
