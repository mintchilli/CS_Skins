using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS_SKINS_ASP.Models;
using Microsoft.AspNet.Identity;

namespace CS_SKINS_ASP.Controllers
{
    public class SujetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sujets
        public ActionResult Index()
        {
            return View(db.Sujet.ToList());
        }

        // GET: Sujets/Details/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujet sujet = db.Sujet.Find(id);
            if (sujet == null)
            {
                return HttpNotFound();
            }
            return View(sujet);
        }

        // GET: Sujets/Create
        [Authorize(Roles = "Administrateur")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sujets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titre,Description,DatePublication,DateDernierPost,Auteur,Dernier,NombrePosts")] Sujet sujet)
        {
            if (ModelState.IsValid)
            {
                sujet.Auteur = db.Users.Find(User.Identity.GetUserId()).UserName;
                //sujet.Dernier = db.Users.Find()
                db.Sujet.Add(sujet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sujet);
        }

        // GET: Sujets/Edit/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujet sujet = db.Sujet.Find(id);
            if (sujet == null)
            {
                return HttpNotFound();
            }
            return View(sujet);
        }

        // POST: Sujets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre,Description,DatePublication,DateDernierPost,Auteur,Dernier,NombrePosts")] Sujet sujet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sujet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sujet);
        }

        // GET: Sujets/Delete/5
        [Authorize(Roles = "Administrateur")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujet sujet = db.Sujet.Find(id);
            if (sujet == null)
            {
                return HttpNotFound();
            }
            return View(sujet);
        }

        // POST: Sujets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sujet sujet = db.Sujet.Find(id);
            db.Sujet.Remove(sujet);
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
