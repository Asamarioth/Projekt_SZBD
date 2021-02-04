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
    public class KONTAKTsController : Controller
    {
        private projektEntities db = new projektEntities();

        // GET: KONTAKTs
        public ActionResult Index()
        {
            return View(db.KONTAKT.ToList());
        }

        // GET: KONTAKTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KONTAKT kONTAKT = db.KONTAKT.Find(id);
            if (kONTAKT == null)
            {
                return HttpNotFound();
            }
            return View(kONTAKT);
        }

        // GET: KONTAKTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KONTAKTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Kontaktu,Telefon_1,Telefon_2,Faks,Email")] KONTAKT kONTAKT)
        {
            if (ModelState.IsValid)
            {
                db.KONTAKT.Add(kONTAKT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kONTAKT);
        }

        // GET: KONTAKTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KONTAKT kONTAKT = db.KONTAKT.Find(id);
            if (kONTAKT == null)
            {
                return HttpNotFound();
            }
            return View(kONTAKT);
        }

        // POST: KONTAKTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Kontaktu,Telefon_1,Telefon_2,Faks,Email")] KONTAKT kONTAKT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kONTAKT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kONTAKT);
        }

        // GET: KONTAKTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KONTAKT kONTAKT = db.KONTAKT.Find(id);
            if (kONTAKT == null)
            {
                return HttpNotFound();
            }
            return View(kONTAKT);
        }

        // POST: KONTAKTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KONTAKT kONTAKT = db.KONTAKT.Find(id);
            db.KONTAKT.Remove(kONTAKT);
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
