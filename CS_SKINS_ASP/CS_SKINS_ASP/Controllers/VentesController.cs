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
    public class VentesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ventes
        public ActionResult Index()
        {
            return View(db.Ventes.ToList());
        }

        // GET: Ventes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventes ventes = db.Ventes.Find(id);
            if (ventes == null)
            {
                return HttpNotFound();
            }
            return View(ventes);
        }

        // GET: Ventes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ventes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ImageNom,ImageType,ImageTaille,ImageData,Prix,ContactInfo,Fichier,NomSkin")] Ventes ventes)
        {
            if (ModelState.IsValid)
            {
                ventes.ImageNom = Path.GetFileName(ventes.Fichier.FileName);
                ventes.ImageTaille = ventes.Fichier.ContentLength;
                ventes.ImageType = ventes.Fichier.ContentType;
                ventes.ImageData = new byte[ventes.ImageTaille];
                ventes.Fichier.InputStream.Read(ventes.ImageData, 0, ventes.ImageTaille);

                db.Ventes.Add(ventes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ventes);
        }

        // GET: Ventes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventes ventes = db.Ventes.Find(id);
            if (ventes == null)
            {
                return HttpNotFound();
            }
            return View(ventes);
        }

        // POST: Ventes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImageNom,ImageType,ImageTaille,ImageData,Prix,ContactInfo")] Ventes ventes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ventes);
        }

        // GET: Ventes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ventes ventes = db.Ventes.Find(id);
            if (ventes == null)
            {
                return HttpNotFound();
            }
            return View(ventes);
        }

        // POST: Ventes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ventes ventes = db.Ventes.Find(id);
            db.Ventes.Remove(ventes);
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
