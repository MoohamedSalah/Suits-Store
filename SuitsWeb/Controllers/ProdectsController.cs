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
using SuitsWeb.ViewModel;

namespace SuitsWeb.Controllers
{
    public class ProdectsController : Controller
    {
        // GET: Prodects
        public ActionResult Index()
        {
            return View(ProdectServes.Instance.Getprodects());
        }

        public PartialViewResult prodectTable(string Search)
        {
            var prodect = ProdectServes.Instance.Getprodects();
            if (string.IsNullOrEmpty(Search) == false)
            {
                prodect = prodect.Where(p => p.Name != null && p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            return PartialView(prodect);

        }
        [Authorize]
        // GET: Prodects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Product = ProdectServes.Instance.Getoneprodect(id);

            if (productViewModel.Product == null)
            {
                return HttpNotFound();
            }
            return View(productViewModel);
        }

        // GET: Prodects/Create
        public ActionResult Create()
        {
            var categorys = CatagorySereves.Instance.GetCategories();
            var viewModel = new VMProductCategory
            {
                categories = categorys
            };
            
            return PartialView(viewModel);
        }

        // POST: Prodects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prodect prodect )
        {
            if (ModelState.IsValid)
            {
                ProdectServes.Instance.Saveprodects(prodect);
                return RedirectToAction("prodectTable");
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }
            //var categorys = CatagorySereves.Instance.GetCategories();
            //var viewModel = new VMProductCategory
            //{
            //    categories = categorys
            //};

            //return PartialView(viewModel);
        }

        // GET: Prodects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prodect prodect = ProdectServes.Instance.Getoneprodect(id);
            if (prodect == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(CatagorySereves.Instance.GetCategories(), "ID", "Name", prodect.categoryID);
            return PartialView(prodect);
        }

        // POST: Prodects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Prodect prodect)
        {
            if (ModelState.IsValid)
            {
                ProdectServes.Instance.Updateprodects(prodect);
                return RedirectToAction("prodectTable");
            }
            ViewBag.categoryID = new SelectList(CatagorySereves.Instance.GetCategories(), "ID", "Name", prodect.categoryID);
            return PartialView(prodect);
        }


        // POST: Prodects/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ProdectServes.Instance.Deleteprodects(id);
            return RedirectToAction("prodectTable");
        }

    }
}
