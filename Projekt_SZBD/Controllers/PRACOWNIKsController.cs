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
    public class PRACOWNIKsController : Controller
    {
        private projektEntities db = new projektEntities();

        // GET: PRACOWNIKs
        public ActionResult Index()
        {
            var pRACOWNIK = db.PRACOWNIK.Include(p => p.ADRES).Include(p => p.KONTAKT);
            return View(pRACOWNIK.ToList());
        }

        // GET: PRACOWNIKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = db.PRACOWNIK.Find(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(pRACOWNIK);
        }

        // GET: PRACOWNIKs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica");
            ViewBag.ID_Kontaktu = new SelectList(db.KONTAKT, "ID_Kontaktu", "Telefon_1");
            return View();
        }

        // POST: PRACOWNIKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Pracownika,Nazwisko,Imie,Data_Zatrudnienia,Pensja,ID_Adresu,ID_Kontaktu")] PRACOWNIK pRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.PRACOWNIK.Add(pRACOWNIK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica", pRACOWNIK.ID_Adresu);
            ViewBag.ID_Kontaktu = new SelectList(db.KONTAKT, "ID_Kontaktu", "Telefon_1", pRACOWNIK.ID_Kontaktu);
            return View(pRACOWNIK);
        }

        // GET: PRACOWNIKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = db.PRACOWNIK.Find(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica", pRACOWNIK.ID_Adresu);
            ViewBag.ID_Kontaktu = new SelectList(db.KONTAKT, "ID_Kontaktu", "Telefon_1", pRACOWNIK.ID_Kontaktu);
            return View(pRACOWNIK);
        }

        // POST: PRACOWNIKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Pracownika,Nazwisko,Imie,Data_Zatrudnienia,Pensja,ID_Adresu,ID_Kontaktu")] PRACOWNIK pRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRACOWNIK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica", pRACOWNIK.ID_Adresu);
            ViewBag.ID_Kontaktu = new SelectList(db.KONTAKT, "ID_Kontaktu", "Telefon_1", pRACOWNIK.ID_Kontaktu);
            return View(pRACOWNIK);
        }

        // GET: PRACOWNIKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = db.PRACOWNIK.Find(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(pRACOWNIK);
        }

        // POST: PRACOWNIKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRACOWNIK pRACOWNIK = db.PRACOWNIK.Find(id);
            db.PRACOWNIK.Remove(pRACOWNIK);
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
