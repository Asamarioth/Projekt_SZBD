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
    public class MAGAZYNsController : Controller
    {
        private projektEntities db = new projektEntities();

        // GET: MAGAZYNs
        public ActionResult Index()
        {
            var mAGAZYN = db.MAGAZYN.Include(m => m.ADRES);
            return View(mAGAZYN.ToList());
        }

        // GET: MAGAZYNs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAGAZYN mAGAZYN = db.MAGAZYN.Find(id);
            if (mAGAZYN == null)
            {
                return HttpNotFound();
            }
            return View(mAGAZYN);
        }

        // GET: MAGAZYNs/Create
        public ActionResult Create()
        {
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica");
            return View();
        }

        // POST: MAGAZYNs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Magazynu,Opis,ID_Adresu")] MAGAZYN mAGAZYN)
        {
            if (ModelState.IsValid)
            {
                db.MAGAZYN.Add(mAGAZYN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica", mAGAZYN.ID_Adresu);
            return View(mAGAZYN);
        }

        // GET: MAGAZYNs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAGAZYN mAGAZYN = db.MAGAZYN.Find(id);
            if (mAGAZYN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica", mAGAZYN.ID_Adresu);
            return View(mAGAZYN);
        }

        // POST: MAGAZYNs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Magazynu,Opis,ID_Adresu")] MAGAZYN mAGAZYN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAGAZYN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Adresu = new SelectList(db.ADRES, "ID_Adresu", "Ulica", mAGAZYN.ID_Adresu);
            return View(mAGAZYN);
        }

        // GET: MAGAZYNs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAGAZYN mAGAZYN = db.MAGAZYN.Find(id);
            if (mAGAZYN == null)
            {
                return HttpNotFound();
            }
            return View(mAGAZYN);
        }

        // POST: MAGAZYNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MAGAZYN mAGAZYN = db.MAGAZYN.Find(id);
            db.MAGAZYN.Remove(mAGAZYN);
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
