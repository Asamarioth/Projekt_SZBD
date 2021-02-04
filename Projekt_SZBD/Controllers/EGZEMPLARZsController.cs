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
    public class EGZEMPLARZsController : Controller
    {
        private projektEntities db = new projektEntities();

        // GET: EGZEMPLARZs
        public ActionResult Index()
        {
            var eGZEMPLARZ = db.EGZEMPLARZ.Include(e => e.MAGAZYN).Include(e => e.PRODUKT);
            return View(eGZEMPLARZ.ToList());
        }

        // GET: EGZEMPLARZs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EGZEMPLARZ eGZEMPLARZ = db.EGZEMPLARZ.Find(id);
            if (eGZEMPLARZ == null)
            {
                return HttpNotFound();
            }
            return View(eGZEMPLARZ);
        }

        // GET: EGZEMPLARZs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Magazynu = new SelectList(db.MAGAZYN, "ID_Magazynu", "Opis");
            ViewBag.ID_Produktu = new SelectList(db.PRODUKT, "ID_Produktu", "Nazwa");
            return View();
        }

        // POST: EGZEMPLARZs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Egzemplarza,Ilosc,ID_Produktu,ID_Magazynu")] EGZEMPLARZ eGZEMPLARZ)
        {
            if (ModelState.IsValid)
            {
                db.EGZEMPLARZ.Add(eGZEMPLARZ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Magazynu = new SelectList(db.MAGAZYN, "ID_Magazynu", "Opis", eGZEMPLARZ.ID_Magazynu);
            ViewBag.ID_Produktu = new SelectList(db.PRODUKT, "ID_Produktu", "Nazwa", eGZEMPLARZ.ID_Produktu);
            return View(eGZEMPLARZ);
        }

        // GET: EGZEMPLARZs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EGZEMPLARZ eGZEMPLARZ = db.EGZEMPLARZ.Find(id);
            if (eGZEMPLARZ == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Magazynu = new SelectList(db.MAGAZYN, "ID_Magazynu", "Opis", eGZEMPLARZ.ID_Magazynu);
            ViewBag.ID_Produktu = new SelectList(db.PRODUKT, "ID_Produktu", "Nazwa", eGZEMPLARZ.ID_Produktu);
            return View(eGZEMPLARZ);
        }

        // POST: EGZEMPLARZs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Egzemplarza,Ilosc,ID_Produktu,ID_Magazynu")] EGZEMPLARZ eGZEMPLARZ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eGZEMPLARZ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Magazynu = new SelectList(db.MAGAZYN, "ID_Magazynu", "Opis", eGZEMPLARZ.ID_Magazynu);
            ViewBag.ID_Produktu = new SelectList(db.PRODUKT, "ID_Produktu", "Nazwa", eGZEMPLARZ.ID_Produktu);
            return View(eGZEMPLARZ);
        }

        // GET: EGZEMPLARZs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EGZEMPLARZ eGZEMPLARZ = db.EGZEMPLARZ.Find(id);
            if (eGZEMPLARZ == null)
            {
                return HttpNotFound();
            }
            return View(eGZEMPLARZ);
        }

        // POST: EGZEMPLARZs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EGZEMPLARZ eGZEMPLARZ = db.EGZEMPLARZ.Find(id);
            db.EGZEMPLARZ.Remove(eGZEMPLARZ);
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
