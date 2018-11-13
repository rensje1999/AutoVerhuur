﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    [Authorize]
    public class KlantensController : Controller
    {
        private Voertuigen_Verhuur_JansenEntities2 db = new Voertuigen_Verhuur_JansenEntities2();

        // GET: Klantens
        public ActionResult Index()
        {
            return View(db.Klantens.ToList());
        }

        // GET: Klantens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klanten klanten = db.Klantens.Find(id);
            if (klanten == null)
            {
                return HttpNotFound();
            }
            return View(klanten);
        }

        // GET: Klantens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klantens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "klantId,voornaam,tussenvoegsel,achternaam,adres,woonplaats,postcode,telNr,mail,wachtwoord")] Klanten klanten)
        {
            if (ModelState.IsValid)
            {
                db.Klantens.Add(klanten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klanten);
        }

        // GET: Klantens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klanten klanten = db.Klantens.Find(id);
            if (klanten == null)
            {
                return HttpNotFound();
            }
            return View(klanten);
        }

        // POST: Klantens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "klantId,voornaam,tussenvoegsel,achternaam,adres,woonplaats,postcode,telNr,mail")] Klanten klanten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klanten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klanten);
        }

        // GET: Klantens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klanten klanten = db.Klantens.Find(id);
            if (klanten == null)
            {
                return HttpNotFound();
            }
            return View(klanten);
        }

        // POST: Klantens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klanten klanten = db.Klantens.Find(id);
            db.Klantens.Remove(klanten);
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
