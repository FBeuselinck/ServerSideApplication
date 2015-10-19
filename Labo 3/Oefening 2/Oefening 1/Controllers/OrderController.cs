using Oefening_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private List<Tablet> Tablets = new List<Tablet>();
        const string COOKIE_STEP1 = "stap 1";

        public OrderController()
        {
            Tablets.Add(new Tablet() { ID = 1, Name = "iPad Mini" });
            Tablets.Add(new Tablet() { ID = 2, Name = "iPad Air" });
            Tablets.Add(new Tablet() { ID = 3, Name = "Nexus 7" });
            Tablets.Add(new Tablet() { ID = 4, Name = "Surface 2" });
        }

        public ActionResult New()
        {

            return View();
        }

        public ActionResult Next(int? step)
        {
            if (step == null)
                return RedirectToAction("New");

            var m = new StateModel(HttpContext);

            switch (step.Value)
            {
                case 1:
                    return View("Step1");
                case 2:
                    /*
                    ViewBag.Company = Request.Form["company"].ToString();
                    ViewBag.FirstName = Request.Form["firstname"].ToString();
                    ViewBag.LastName = Request.Form["lastname"].ToString();
                    */

                    ViewBag.Tablets = Tablets;

                    var valueStep1 = string.Format("{0}-{1}-{2}", Request.Form["company"].ToString(), Request.Form["firstname"].ToString(), Request.Form["lastname"].ToString());
                    m.Save(COOKIE_STEP1, valueStep1);

                    return View("Step2");
                case 3:
                    /*
                    ViewBag.Company = Request.Form["company"].ToString();
                    ViewBag.FirstName = Request.Form["firstname"].ToString();
                    ViewBag.LastName = Request.Form["lastname"].ToString();
                    */

                    
                    string value = m.Load(COOKIE_STEP1);
                    if(!string.IsNullOrEmpty(value))
                    {
                        string[] parts = value.Split('-');
                        ViewBag.Company = parts[0];
                        ViewBag.FirstName = parts[1];
                        ViewBag.LastName = parts[2];
                    }

                    int tabletId = int.Parse(Request.Form["tablet"].ToString());
                    ViewBag.Tablet = Tablets.Find(t => t.ID == tabletId).Name;
                    if (!String.IsNullOrEmpty(Request.Form["case"]))
                        ViewBag.Case = true;
                    else
                        ViewBag.Case = false;

                    if (!String.IsNullOrEmpty(Request.Form["assurance"]))
                        ViewBag.Assurance = true;
                    else
                        ViewBag.Assurance = false;

                    return View("Step3");
                default:
                    return RedirectToAction("New");
            }
        }
    }
}