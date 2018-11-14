using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoVerhuurJansen.Models;

namespace AutoVerhuurJansen.Controllers
{
    public class VerhurensController : Controller
    {
        private Auto_Verhuur_JansenEntities db = new Auto_Verhuur_JansenEntities();

        // GET: Verhurens
        public ActionResult Index()
        {
            var verhurens = db.Verhurens.Include(v => v.Klanten).Include(v => v.Voertuigen);
            return View(verhurens.ToList());
        }

        // GET: Verhurens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verhuren verhuren = db.Verhurens.Find(id);
            if (verhuren == null)
            {
                return HttpNotFound();
            }
            return View(verhuren);
        }

        // GET: Verhurens/Create
        public ActionResult Create()
        {
            ViewBag.klantId = new SelectList(db.Klantens, "klantId", "voornaam");
            ViewBag.kenteken = new SelectList(db.Voertuigens, "kenteken", "merk");
            return View();
        }

        // POST: Verhurens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VerhuurId,klantId,kenteken,medewerkerId,beginDatum,eindDatum,afgehandeld")] Verhuren verhuren)
        {
            if (ModelState.IsValid)
            {
                db.Verhurens.Add(verhuren);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klantId = new SelectList(db.Klantens, "klantId", "voornaam", verhuren.klantId);
            ViewBag.kenteken = new SelectList(db.Voertuigens, "kenteken", "merk", verhuren.kenteken);
            return View(verhuren);
        }

        // GET: Verhurens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verhuren verhuren = db.Verhurens.Find(id);
            if (verhuren == null)
            {
                return HttpNotFound();
            }
            ViewBag.klantId = new SelectList(db.Klantens, "klantId", "voornaam", verhuren.klantId);
            ViewBag.kenteken = new SelectList(db.Voertuigens, "kenteken", "merk", verhuren.kenteken);
            return View(verhuren);
        }

        // POST: Verhurens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VerhuurId,klantId,kenteken,medewerkerId,beginDatum,eindDatum,afgehandeld")] Verhuren verhuren)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verhuren).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klantId = new SelectList(db.Klantens, "klantId", "voornaam", verhuren.klantId);
            ViewBag.kenteken = new SelectList(db.Voertuigens, "kenteken", "merk", verhuren.kenteken);
            return View(verhuren);
        }

        // GET: Verhurens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verhuren verhuren = db.Verhurens.Find(id);
            if (verhuren == null)
            {
                return HttpNotFound();
            }
            return View(verhuren);
        }

        // POST: Verhurens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verhuren verhuren = db.Verhurens.Find(id);
            db.Verhurens.Remove(verhuren);
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
