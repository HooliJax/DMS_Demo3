﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testDMS.Models;

namespace testDMS.Controllers
{
    public class DONATIONsController : Controller
    {
        private DonorManagementDatabaseEntities db = new DonorManagementDatabaseEntities();

        // GET: DONATIONs
        public ActionResult Index()
        {
            var dONATIONs = db.DONATIONs.Include(d => d.CODE).Include(d => d.DONOR);
            return View(dONATIONs.ToList());
        }

        // GET: DONATIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONATION dONATION = db.DONATIONs.Find(id);
            if (dONATION == null)
            {
                return HttpNotFound();
            }
            return View(dONATION);
        }

        // GET: DONATIONs/Create
        public ActionResult Create()
        {
            ViewBag.CodeId = new SelectList(db.CODES, "CodeId", "Fund");
            ViewBag.DonorId = new SelectList(db.DONORs, "DONORID", "FNAME");
            return View();
        }

        // POST: DONATIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationId,DonorId,Amount,TypeOf,DateRecieved,GiftMethod,DateGiftMade,CodeId,ImageUpload,GiftRestrictions")] DONATION dONATION)
        {
            if (ModelState.IsValid)
            {
                db.DONATIONs.Add(dONATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodeId = new SelectList(db.CODES, "CodeId", "Fund", dONATION.CodeId);
            ViewBag.DonorId = new SelectList(db.DONORs, "DONORID", "FNAME", dONATION.DonorId);
            return View(dONATION);
        }

        // GET: DONATIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONATION dONATION = db.DONATIONs.Find(id);
            if (dONATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodeId = new SelectList(db.CODES, "CodeId", "Fund", dONATION.CodeId);
            ViewBag.DonorId = new SelectList(db.DONORs, "DONORID", "FNAME", dONATION.DonorId);
            return View(dONATION);
        }

        // POST: DONATIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationId,DonorId,Amount,TypeOf,DateRecieved,GiftMethod,DateGiftMade,CodeId,ImageUpload,GiftRestrictions")] DONATION dONATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodeId = new SelectList(db.CODES, "CodeId", "Fund", dONATION.CodeId);
            ViewBag.DonorId = new SelectList(db.DONORs, "DONORID", "FNAME", dONATION.DonorId);
            return View(dONATION);
        }

        // GET: DONATIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONATION dONATION = db.DONATIONs.Find(id);
            if (dONATION == null)
            {
                return HttpNotFound();
            }
            return View(dONATION);
        }

        // POST: DONATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONATION dONATION = db.DONATIONs.Find(id);
            db.DONATIONs.Remove(dONATION);
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