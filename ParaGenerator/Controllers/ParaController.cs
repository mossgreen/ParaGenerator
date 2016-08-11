using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParaGenerator.Models;

namespace ParaGenerator.Controllers
{
    public class ParaController : Controller
    {
        private ParaDBEntities db = new ParaDBEntities();

        // GET: Para
        public ActionResult Index()
        {
            var paras = db.Paras.Include(p => p.ParaLeft).Include(p => p.ParaRight);
            return View(paras.ToList());
        }

        // GET: Para/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Para para = db.Paras.Find(id);
            if (para == null)
            {
                return HttpNotFound();
            }
            return View(para);
        }

        // GET: Para/Create
        public ActionResult Create()
        {
            ViewBag.ParaId = new SelectList(db.ParaLefts, "ParaId", "ParaId");
            ViewBag.ParaId = new SelectList(db.ParaRights, "ParaId", "ParaId");
            return View();
        }

        // POST: Para/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParaId,ParaText")] Para para)
        {
            if (ModelState.IsValid)
            {
                db.Paras.Add(para);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParaId = new SelectList(db.ParaLefts, "ParaId", "ParaId", para.ParaId);
            ViewBag.ParaId = new SelectList(db.ParaRights, "ParaId", "ParaId", para.ParaId);
            return View(para);
        }

        // GET: Para/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Para para = db.Paras.Find(id);
            if (para == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParaId = new SelectList(db.ParaLefts, "ParaId", "ParaId", para.ParaId);
            ViewBag.ParaId = new SelectList(db.ParaRights, "ParaId", "ParaId", para.ParaId);
            return View(para);
        }

        // POST: Para/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParaId,ParaText")] Para para)
        {
            if (ModelState.IsValid)
            {
                db.Entry(para).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParaId = new SelectList(db.ParaLefts, "ParaId", "ParaId", para.ParaId);
            ViewBag.ParaId = new SelectList(db.ParaRights, "ParaId", "ParaId", para.ParaId);
            return View(para);
        }

        // GET: Para/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Para para = db.Paras.Find(id);
            if (para == null)
            {
                return HttpNotFound();
            }
            return View(para);
        }

        // POST: Para/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Para para = db.Paras.Find(id);
            db.Paras.Remove(para);
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
