﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoekertjes.WebApp.DataAccess;
using Zoekertjes.WebApp.Models;
using Zoekertjes.WebApp.PresentationModels;

namespace Zoekertjes.WebApp.Controllers
{
    public class ZoekertjesController : Controller
    {
        //
        // GET: /Zoekertjes/
        public ActionResult Index()
        {
            List<Zoekertje> alleZoekertjes = new List<Zoekertje>();
            alleZoekertjes = Data.GetZoekertjes();
            return View(alleZoekertjes);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            Zoekertje zoekertje = Data.GetZoekertje(id.Value);

            Categorie categorie = Data.GetCategorie(zoekertje.CategorieId);
            ViewBag.Categorie = categorie.Naam;

            Locatie locatie = Data.GetLocatie(zoekertje.LocatieId);
            ViewBag.Locatie = locatie.Naam;

            return View(zoekertje);
        }

        [HttpGet]
        public ActionResult New()
        {
            PMNewZoekertje zoekertje = new PMNewZoekertje();
            zoekertje.NewZoekertje = new Zoekertje();
            zoekertje.Categories = new SelectList(Data.GetCategories(), "Id", "Naam");
            zoekertje.Locaties = new SelectList(Data.GetLocaties(), "Id", "Naam");
            return View(zoekertje);
        }

        [HttpPost]
        public ActionResult New(PMNewZoekertje zoekertje)
        {
            zoekertje.Categories = new SelectList(Data.GetCategories(), "Id", "Naam");
            zoekertje.Locaties = new SelectList(Data.GetLocaties(), "Id", "Naam");
            if (ModelState.IsValid)
            {
                Data.AddZoekertje(zoekertje.NewZoekertje);
                List<Zoekertje> alleZoekertjes = new List<Zoekertje>();
                alleZoekertjes = Data.GetZoekertjes();
                return View("Index", alleZoekertjes);
            }
            else
            {
                return View("New", zoekertje);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            List<DeleteReden> deleteRedens = Data.GetDeleteRedens();
            ViewBag.DeleteRedens = deleteRedens;

            Zoekertje zoekertje = Data.GetZoekertje(id.Value);
            return View(zoekertje);
        }

        [HttpPost]
        public ActionResult Delete(Zoekertje zoekertje)
        {
            Data.DeleteZoekertjes(zoekertje.Id);
            List<Zoekertje> alleZoekertjes = new List<Zoekertje>();
            alleZoekertjes = Data.GetZoekertjes();
            return View("Index", alleZoekertjes);
        }
	}
}