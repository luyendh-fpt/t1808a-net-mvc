using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1808A_MVC.Models;

namespace T1808A_MVC.Controllers
{
    public class OtherClassesController : Controller
    {
        private T1808A_MVCContext db = new T1808A_MVCContext();

        // GET: OtherClasses
        public ActionResult Index()
        {
            return View(db.OtherClasses.ToList());
        }

        // GET: OtherClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherClass otherClass = db.OtherClasses.Find(id);
            if (otherClass == null)
            {
                return HttpNotFound();
            }
            return View(otherClass);
        }

        // GET: OtherClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtherClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] OtherClass otherClass)
        {
            if (ModelState.IsValid)
            {
                db.OtherClasses.Add(otherClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(otherClass);
        }

        // GET: OtherClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherClass otherClass = db.OtherClasses.Find(id);
            if (otherClass == null)
            {
                return HttpNotFound();
            }
            return View(otherClass);
        }

        // POST: OtherClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] OtherClass otherClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otherClass);
        }

        // GET: OtherClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherClass otherClass = db.OtherClasses.Find(id);
            if (otherClass == null)
            {
                return HttpNotFound();
            }
            return View(otherClass);
        }

        // POST: OtherClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtherClass otherClass = db.OtherClasses.Find(id);
            db.OtherClasses.Remove(otherClass);
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
