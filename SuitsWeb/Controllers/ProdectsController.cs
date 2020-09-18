﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Suites.Entities;
using Suites.Serveres;
using SuitsWeb.Models;

namespace SuitsWeb.Controllers
{
    public class ProdectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ProdectServes ProdectServes = new ProdectServes();

        // GET: Prodects
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult prodectTable(string Search)
        {
            var prodect = ProdectServes.Getprodects();
            if(string.IsNullOrEmpty(Search)==false  )
            {
                prodect = prodect.Where(p =>p.Name !=null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            return PartialView(prodect);

        }

        // GET: Prodects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodect prodect = ProdectServes.Getoneprodects(id);
            if (prodect == null)
            {
                return HttpNotFound();
            }
            return View(prodect);
        }

        // GET: Prodects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prodects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Prodect prodect)
        {
            if (ModelState.IsValid)
            {
                ProdectServes.Saveprodects(prodect);
                return RedirectToAction("Index");
            }

            return View(prodect);
        }

        // GET: Prodects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodect prodect = ProdectServes.Getoneprodects(id);
            if (prodect == null)
            {
                return HttpNotFound();
            }
            return View(prodect);
        }

        // POST: Prodects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Prodect prodect)
        {
            if (ModelState.IsValid)
            {
                ProdectServes.Updateprodects(prodect);
                return RedirectToAction("Index");
            }
            return View(prodect);
        }

        // GET: Prodects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodect prodect = ProdectServes.Getoneprodects(id);
            if (prodect == null)
            {
                return HttpNotFound();
            }
            return View(prodect);
        }

        // POST: Prodects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdectServes.Deleteprodects(id);
            return RedirectToAction("Index");
        }

    }
}