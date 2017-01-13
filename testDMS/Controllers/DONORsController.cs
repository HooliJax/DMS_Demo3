﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using testDMS.Models;
using testDMS.DAL;

namespace testDMS.Controllers
{
    public class DONORsController : Controller
    {
        private DonorManagementDatabaseEntities data = new DonorManagementDatabaseEntities();
        //private DonorRepository drRepo = new DonorRepository();
        //private DonationRepository dnRepo = new DonationRepository();
        IDonorRepository drRepo;
        IDonationRepository dnRepo;

        public DONORsController(IDonorRepository drRepo, IDonationRepository dnRepo)
        {
            this.drRepo = drRepo;
            this.dnRepo = dnRepo;
        }

        public ActionResult Index()
        {
            return View(drRepo.GetDonors());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONOR donor = drRepo.FindById(Convert.ToInt32(id));
            if (donor == null)
            {
                return HttpNotFound();
            }

            ViewBag.COMPANYID = new SelectList(data.Company, "COMPANYID", "COMPANYNAME", donor.COMPANYID);
            ViewBag.CONTACTID = new SelectList(data.Contact, "CONTACTID", "TYPEOF", donor.CONTACTID);
            ViewBag.MARKERID = new SelectList(data.IdentityMarker, "MARKERID", "MARKERTYPE", donor.MARKERID);

            return View(donor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DONORID,FNAME,MINIT,LNAME,TITLE,SUFFIX,EMAIL,CELL,BIRTHDAY,GENDER,MARKERID,CONTACTID,COMPANYID")] DONOR donor)
        {
            if (ModelState.IsValid)
            {
                drRepo.Edit(donor);
                return RedirectToAction("Index");
            }
            ViewBag.COMPANYID = new SelectList(data.Company, "COMPANYID", "COMPANYNAME", donor.COMPANYID);
            ViewBag.CONTACTID = new SelectList(data.Contact, "CONTACTID", "TYPEOF", donor.CONTACTID);
            ViewBag.MARKERID = new SelectList(data.IdentityMarker, "MARKERID", "MARKERTYPE", donor.MARKERID);
            return View(donor);
        }

        public ActionResult Details(int? id)//parameter HAS to be called id for whatever reason???
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONOR donor  = drRepo.FindById(Convert.ToInt32(id));
            if (donor == null)
            {
                return HttpNotFound();
            }
            return View(donor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DONORID,FNAME,MINIT,LNAME,TITLE,SUFFIX,EMAIL,CELL,BIRTHDAY,GENDER,MARKERID,CONTACTID,COMPANYID")] DONOR donor)
        {
            if (ModelState.IsValid)
            {
                drRepo.Add(donor);
                return RedirectToAction("Index");
            }

            ViewBag.COMPANYID = new SelectList(data.Company, "COMPANYID", "COMPANYNAME", donor.COMPANYID);
            ViewBag.CONTACTID = new SelectList(data.Contact, "CONTACTID", "TYPEOF", donor.CONTACTID);
            ViewBag.MARKERID = new SelectList(data.IdentityMarker, "MARKERID", "MARKERTYPE", donor.MARKERID);
            return View(donor);
        }

        public ActionResult LoadDonations(int? id)//partial view
        {
            var allDonations = dnRepo.GetDonations();
            

            return View(dnRepo.GetDonations());
        }

    }
}
