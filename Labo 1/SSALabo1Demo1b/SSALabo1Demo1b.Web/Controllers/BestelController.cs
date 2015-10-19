using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSALabo1Demo1b.Web.Controllers
{
    public class BestelController : Controller
    {
        //
        // GET: /Bestel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stap1()
        {
            return View();
        }

        public ActionResult Stap2(string bedrijf, string voornaam, string achternaam)
        {
            if (string.IsNullOrEmpty(bedrijf) ||
               string.IsNullOrEmpty(voornaam) ||
               string.IsNullOrEmpty(achternaam))
            {
                return View("Error");
            }

            ViewBag.Bedrijf = bedrijf;
            ViewBag.Voornaam = voornaam;
            ViewBag.Achternaam = achternaam;

            return View();
        }

        public ActionResult Overzicht(string bedrijf, string voornaam, string achternaam, string product, String[] accessoires)
        {
            ViewBag.Bedrijf = bedrijf;
            ViewBag.Voornaam = voornaam;
            ViewBag.Achternaam = achternaam;
            ViewBag.Product = product;
            ViewBag.Accessoires = accessoires;

            return View();
        }
    }
}
