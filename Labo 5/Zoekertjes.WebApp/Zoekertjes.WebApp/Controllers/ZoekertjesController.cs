using System;
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
        private const string PHONE_COOKIE = "save-phone";
        private const string MAIL_COOKIE = "mail-phone";

        public ActionResult Index()
        {
            List<Zoekertje> alleZoekertjes = new List<Zoekertje>();
            alleZoekertjes = Data.GetZoekertjes();
            return View(alleZoekertjes);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

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
            zoekertje.Categories = new SelectList(Data.GetCategories(), "Id", "Naam");
            zoekertje.Locaties = new SelectList(Data.GetLocaties(), "Id", "Naam");
            return View(zoekertje);
        }

        [HttpPost]
        public ActionResult New(PMNewZoekertje zoekertje)
        {
            if (ModelState.IsValid)
            {
                Data.AddZoekertje(zoekertje.NewZoekertje);
                return RedirectToAction("Index");
            }
            else
            {
                zoekertje.Categories = new SelectList(Data.GetCategories(), "Id", "Naam");
                zoekertje.Locaties = new SelectList(Data.GetLocaties(), "Id", "Naam");
                return View(zoekertje);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("index");

            Zoekertje zoekertje = Data.GetZoekertje(id.Value);
            if (zoekertje == null)
                return RedirectToAction("index");
            ViewBag.DeleteRedens = Data.GetDeleteRedens();
            return View(zoekertje);

        }

        [HttpPost]
        public ActionResult Delete(int? id,int? reden)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");
            Data.DeleteZoekertjes(id.Value);

            return RedirectToAction("Index");
        }

        public ActionResult IndexAjax()
        {
            return View();
        }
    }
}