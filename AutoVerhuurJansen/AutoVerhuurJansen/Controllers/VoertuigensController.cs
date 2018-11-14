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
    public class VoertuigensController : Controller
    {
        private Auto_Verhuur_JansenEntities db = new Auto_Verhuur_JansenEntities();

        // GET: Voertuigens
        public ActionResult Index()
        {
            var voertuigens = db.Voertuigens.Include(v => v.categorie);
            return View(voertuigens.ToList());
        }

        // GET: Voertuigens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voertuigen voertuigen = db.Voertuigens.Find(id);
            if (voertuigen == null)
            {
                return HttpNotFound();
            }
            return View(voertuigen);
        }

        // GET: Voertuigens/Create
        public ActionResult Create()
        {
            ViewBag.categorieId = new SelectList(db.categories, "categorieId", "categorieNaam");
            return View();
        }

        // POST: Voertuigens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kenteken,categorieId,merk,type")] Voertuigen voertuigen)
        {
            if (ModelState.IsValid)
            {
                db.Voertuigens.Add(voertuigen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categorieId = new SelectList(db.categories, "categorieId", "categorieNaam", voertuigen.categorieId);
            return View(voertuigen);
        }

        // GET: Voertuigens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voertuigen voertuigen = db.Voertuigens.Find(id);
            if (voertuigen == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorieId = new SelectList(db.categories, "categorieId", "categorieNaam", voertuigen.categorieId);
            return View(voertuigen);
        }

        // POST: Voertuigens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kenteken,categorieId,merk,type")] Voertuigen voertuigen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voertuigen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categorieId = new SelectList(db.categories, "categorieId", "categorieNaam", voertuigen.categorieId);
            return View(voertuigen);
        }

        // GET: Voertuigens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voertuigen voertuigen = db.Voertuigens.Find(id);
            if (voertuigen == null)
            {
                return HttpNotFound();
            }
            return View(voertuigen);
        }

        // POST: Voertuigens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Voertuigen voertuigen = db.Voertuigens.Find(id);
            db.Voertuigens.Remove(voertuigen);
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
