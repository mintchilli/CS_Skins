using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS_SKINS_ASP.Models;

namespace CS_SKINS_ASP.Controllers
{
    public class SkinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Skins
        public ActionResult Index(int id = 0)
        {
            if (HttpContext.Request.Cookies["cookie_skins"] == null)
            {
                HttpCookie cookie = new HttpCookie("cookie_skins");
                cookie.Value = id.ToString();
                HttpContext.Response.Cookies.Remove("cookie_skins");
                HttpContext.Response.SetCookie(cookie);
            }
            int IDCook = Convert.ToInt32(HttpContext.Request.Cookies.Get("cookie_skins").Value);

            return View(db.Skins.Where(c=> c.CrateId == IDCook).ToList());
        }

        // GET: Skins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skins skins = db.Skins.Find(id);
            if (skins == null)
            {
                return HttpNotFound();
            }
            return View(skins);
        }

        // GET: Skins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Prix,Probabilité,Rang")] Skins skins)
        {
            if (ModelState.IsValid)
            {
                int cookieId = Convert.ToInt32(HttpContext.Request.Cookies.Get("cookie_skins").Value);
                skins.CrateId = cookieId;
                db.Skins.Add(skins);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skins);
        }

        // GET: Skins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skins skins = db.Skins.Find(id);
            if (skins == null)
            {
                return HttpNotFound();
            }
            return View(skins);
        }

        // POST: Skins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Prix,Probabilité,Rang")] Skins skins)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skins).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skins);
        }

        // GET: Skins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skins skins = db.Skins.Find(id);
            if (skins == null)
            {
                return HttpNotFound();
            }
            return View(skins);
        }

        // POST: Skins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skins skins = db.Skins.Find(id);
            db.Skins.Remove(skins);
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
