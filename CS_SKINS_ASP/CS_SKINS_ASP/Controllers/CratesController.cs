using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS_SKINS_ASP.Models;
using System.IO;

namespace CS_SKINS_ASP.Controllers
{
    public class CratesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Crates
        public ActionResult Index()
        {
            return View(db.Crates.ToList());
        }

        // GET: Crates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crate crate = db.Crates.Find(id);
            if (crate == null)
            {
                return HttpNotFound();
            }
            return View(crate);
        }

        // GET: Crates/Create
        [Authorize(Roles = "Administrateur")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Prix,Fichier")] Crate crate)
        {
            if (ModelState.IsValid)
            {
                crate.ImageNom = Path.GetFileName(crate.Fichier.FileName);
                crate.ImageTaille = crate.Fichier.ContentLength;
                crate.ImageType = crate.Fichier.ContentType;
                crate.ImageData = new byte[crate.ImageTaille];
                crate.Fichier.InputStream.Read(crate.ImageData, 0, crate.ImageTaille);
                db.Crates.Add(crate);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crate);
        }

        // GET: Crates/Edit/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crate crate = db.Crates.Find(id);
            if (crate == null)
            {
                return HttpNotFound();
            }
            return View(crate);
        }

        // POST: Crates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Prix,ImageNom,ImageType,ImageTaille,ImageData")] Crate crate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crate);
        }

        // GET: Crates/Delete/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crate crate = db.Crates.Find(id);
            if (crate == null)
            {
                return HttpNotFound();
            }
            return View(crate);
        }

        // POST: Crates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crate crate = db.Crates.Find(id);
            db.Crates.Remove(crate);
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
