using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class CateriesController : Controller
    {
        private Voertuigen_Verhuur_JansenEntities2 db = new Voertuigen_Verhuur_JansenEntities2();

        // GET: Cateries
        public ActionResult Index()
        {
            return View(db.Cateries.ToList());
        }

        // GET: Cateries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterie caterie = db.Cateries.Find(id);
            if (caterie == null)
            {
                return HttpNotFound();
            }
            return View(caterie);
        }

        // GET: Cateries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cateries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "caterieId,caterieNaam,aantalPersonen,aantalKoffers")] Caterie caterie)
        {
            if (ModelState.IsValid)
            {
                db.Cateries.Add(caterie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caterie);
        }

        // GET: Cateries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterie caterie = db.Cateries.Find(id);
            if (caterie == null)
            {
                return HttpNotFound();
            }
            return View(caterie);
        }

        // POST: Cateries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "caterieId,caterieNaam,aantalPersonen,aantalKoffers")] Caterie caterie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caterie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caterie);
        }

        // GET: Cateries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caterie caterie = db.Cateries.Find(id);
            if (caterie == null)
            {
                return HttpNotFound();
            }
            return View(caterie);
        }

        // POST: Cateries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caterie caterie = db.Cateries.Find(id);
            db.Cateries.Remove(caterie);
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
