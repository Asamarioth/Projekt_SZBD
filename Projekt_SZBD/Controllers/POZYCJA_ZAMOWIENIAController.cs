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
    public class POZYCJA_ZAMOWIENIAController : Controller
    {
        private projektEntities db = new projektEntities();

        // GET: POZYCJA_ZAMOWIENIA
        public ActionResult Index()
        {
            var pOZYCJA_ZAMOWIENIA = db.POZYCJA_ZAMOWIENIA.Include(p => p.EGZEMPLARZ).Include(p => p.MAGAZYN).Include(p => p.PRODUKT).Include(p => p.ZAMOWIENIA);
            return View(pOZYCJA_ZAMOWIENIA.ToList());
        }

        // GET: POZYCJA_ZAMOWIENIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POZYCJA_ZAMOWIENIA pOZYCJA_ZAMOWIENIA = db.POZYCJA_ZAMOWIENIA.Find(id);
            if (pOZYCJA_ZAMOWIENIA == null)
            {
                return HttpNotFound();
            }
            return View(pOZYCJA_ZAMOWIENIA);
        }

        // GET: POZYCJA_ZAMOWIENIA/Create
        public ActionResult Create()
        {
            ViewBag.ID_Egzemplarza = new SelectList(db.EGZEMPLARZ, "ID_Egzemplarza", "ID_Egzemplarza");
            ViewBag.ID_Magazynu = new SelectList(db.MAGAZYN, "ID_Magazynu", "Opis");
            ViewBag.ID_Produktu = new SelectList(db.PRODUKT, "ID_Produktu", "Nazwa");
            ViewBag.ID_Zamowienia = new SelectList(db.ZAMOWIENIA, "ID_Zamowienia", "ID_Zamowienia");
            return View();
        }

        // POST: POZYCJA_ZAMOWIENIA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Pozycji_Zamowienia,Czy_Kupno_Od_Klienta,Kwota,Ilosc,ID_Zamowienia,ID_Produktu,ID_Egzemplarza,ID_Magazynu")] POZYCJA_ZAMOWIENIA pOZYCJA_ZAMOWIENIA)
        {
            if (ModelState.IsValid)
            {
                db.POZYCJA_ZAMOWIENIA.Add(pOZYCJA_ZAMOWIENIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Egzemplarza = new SelectList(db.EGZEMPLARZ, "ID_Egzemplarza", "ID_Egzemplarza", pOZYCJA_ZAMOWIENIA.ID_Egzemplarza);
            ViewBag.ID_Magazynu = new SelectList(db.MAGAZYN, "ID_Magazynu", "Opis", pOZYCJA_ZAMOWIENIA.ID_Magazynu);
            ViewBag.ID_Produktu = new SelectList(db.PRODUKT, "ID_Produktu", "Nazwa", pOZYCJA_ZAMOWIENIA.ID_Produktu);
            ViewBag.ID_Zamowienia = new SelectList(db.ZAMOWIENIA, "ID_Zamowienia", "ID_Zamowienia", pOZYCJA_ZAMOWIENIA.ID_Zamowienia);
            return View(pOZYCJA_ZAMOWIENIA);
        }

        // GET: POZYCJA_ZAMOWIENIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POZYCJA_ZAMOWIENIA pOZYCJA_ZAMOWIENIA = db.POZYCJA_ZAMOWIENIA.Find(id);
            if (pOZYCJA_ZAMOWIENIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Egzemplarza = new SelectList(db.EGZEMPLARZ, "ID_Egzemplarza", "ID_Egzemplarza", pOZYCJA_ZAMOWIENIA.ID_Egzemplarza);
            ViewBag.ID_Magazynu = new SelectList(db.MAGAZYN, "ID_Magazynu", "Opis", pOZYCJA_ZAMOWIENIA.ID_Magazynu);
            ViewBag.ID_Produktu = new SelectList(db.PRODUKT, "ID_Produktu", "Nazwa", pOZYCJA_ZAMOWIENIA.ID_Produktu);
            ViewBag.ID_Zamowienia = new SelectList(db.ZAMOWIENIA, "ID_Zamowienia", "ID_Zamowienia", pOZYCJA_ZAMOWIENIA.ID_Zamowienia);
            return View(pOZYCJA_ZAMOWIENIA);
        }

        // POST: POZYCJA_ZAMOWIENIA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Pozycji_Zamowienia,Czy_Kupno_Od_Klienta,Kwota,Ilosc,ID_Zamowienia,ID_Produktu,ID_Egzemplarza,ID_Magazynu")] POZYCJA_ZAMOWIENIA pOZYCJA_ZAMOWIENIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOZYCJA_ZAMOWIENIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Egzemplarza = new SelectList(db.EGZEMPLARZ, "ID_Egzemplarza", "ID_Egzemplarza", pOZYCJA_ZAMOWIENIA.ID_Egzemplarza);
            ViewBag.ID_Magazynu = new SelectList(db.MAGAZYN, "ID_Magazynu", "Opis", pOZYCJA_ZAMOWIENIA.ID_Magazynu);
            ViewBag.ID_Produktu = new SelectList(db.PRODUKT, "ID_Produktu", "Nazwa", pOZYCJA_ZAMOWIENIA.ID_Produktu);
            ViewBag.ID_Zamowienia = new SelectList(db.ZAMOWIENIA, "ID_Zamowienia", "ID_Zamowienia", pOZYCJA_ZAMOWIENIA.ID_Zamowienia);
            return View(pOZYCJA_ZAMOWIENIA);
        }

        // GET: POZYCJA_ZAMOWIENIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POZYCJA_ZAMOWIENIA pOZYCJA_ZAMOWIENIA = db.POZYCJA_ZAMOWIENIA.Find(id);
            if (pOZYCJA_ZAMOWIENIA == null)
            {
                return HttpNotFound();
            }
            return View(pOZYCJA_ZAMOWIENIA);
        }

        // POST: POZYCJA_ZAMOWIENIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POZYCJA_ZAMOWIENIA pOZYCJA_ZAMOWIENIA = db.POZYCJA_ZAMOWIENIA.Find(id);
            db.POZYCJA_ZAMOWIENIA.Remove(pOZYCJA_ZAMOWIENIA);
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
