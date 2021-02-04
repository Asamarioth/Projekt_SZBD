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
    public class KLIENTsController : Controller
    {
        private projektEntities db = new projektEntities();

        // GET: KLIENTs
        public ActionResult Index()
        {
            var kLIENT = db.KLIENT.Include(k => k.ADRES).Include(k => k.KONTAKT);
            return View(kLIENT.ToList());
        }

        // GET: KLIENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KLIENT kLIENT = db.KLIENT.Find(id);
            if (kLIENT == null)
            {
                return HttpNotFound();
            }
            return View(kLIENT);
        }

        // GET: KLIENTs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica");
            ViewBag.ID_Kontaktu = new SelectList(db.KONTAKT, "ID_Kontaktu", "Telefon_1");
            return View();
        }

        // POST: KLIENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Klienta,Nazwa,Czy_Firma,NIP,ID_Adresu,ID_Kontaktu")] KLIENT kLIENT)
        {
            if (ModelState.IsValid)
            {
                db.KLIENT.Add(kLIENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica", kLIENT.ID_Adresu);
            ViewBag.ID_Kontaktu = new SelectList(db.KONTAKT, "ID_Kontaktu", "Telefon_1", kLIENT.ID_Kontaktu);
            return View(kLIENT);
        }

        // GET: KLIENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KLIENT kLIENT = db.KLIENT.Find(id);
            if (kLIENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica + Miejscowosc", kLIENT.ID_Adresu);
            ViewBag.ID_Kontaktu = new SelectList(db.KONTAKT, "ID_Kontaktu", "Telefon_1", kLIENT.ID_Kontaktu);
            return View(kLIENT);
        }

        // POST: KLIENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Klienta,Nazwa,Czy_Firma,NIP,ID_Adresu,ID_Kontaktu")] KLIENT kLIENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kLIENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica", kLIENT.ID_Adresu);
            ViewBag.ID_Kontaktu = new SelectList(db.KONTAKT, "ID_Kontaktu", "Telefon_1", kLIENT.ID_Kontaktu);
            return View(kLIENT);
        }

        // GET: KLIENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KLIENT kLIENT = db.KLIENT.Find(id);
            if (kLIENT == null)
            {
                return HttpNotFound();
            }
            return View(kLIENT);
        }

        // POST: KLIENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KLIENT kLIENT = db.KLIENT.Find(id);
            db.KLIENT.Remove(kLIENT);
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
