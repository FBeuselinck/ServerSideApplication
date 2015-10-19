using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderController : Controller
    {
        private List<Tablet> Tablets = new List<Tablet>();
        private const string COOKIE_NAME = "step";
        private const string COOKIE_DATA_STEP1 = "step1";
        private const string COOKIE_DATA_STEP2 = "step2";
        private DateTime COOKIE_EXPIRE = DateTime.Now.AddDays(1);

        public OrderController()
        {
            Tablets.Add(new Tablet() { ID = 1, Name = "iPad Mini" });
            Tablets.Add(new Tablet() { ID = 2, Name = "iPad Air" });
            Tablets.Add(new Tablet() { ID = 3, Name = "Nexus 7" });
            Tablets.Add(new Tablet() { ID = 4, Name = "Surface 2" });
        }

        public ActionResult New()
        {
            if (Request.Cookies[COOKIE_NAME] == null) { 
            return View();
            }
            else
            {
                int step = int.Parse(Request.Cookies[COOKIE_NAME].Value);
                return RedirectToAction("Next",new  { step = step});
            }
        }

        public ActionResult Next(int? step)
        {
            if (step == null)
                return RedirectToAction("New");
          
            
            HttpCookie cookie = new HttpCookie(COOKIE_NAME, step.Value.ToString());
            cookie.Expires = COOKIE_EXPIRE;
            Response.SetCookie(cookie);


            switch (step.Value)
            {
                case 1:
                    if (Request.Cookies[COOKIE_DATA_STEP1] != null)
                    {
                        string rawData = Request.Cookies[COOKIE_DATA_STEP1].Value.ToString();
                        string company = rawData.Split('-')[0];
                        string firstname = rawData.Split('-')[1];
                        string lastname = rawData.Split('-')[2];

                        ViewBag.Company = company;
                        ViewBag.FirstName = firstname;
                        ViewBag.LastName = lastname;
                    }
                   return View("Step1");
                case 2:

                   if(Request.Cookies[COOKIE_DATA_STEP1] != null){
                       string rawData = Request.Cookies[COOKIE_DATA_STEP1].Value.ToString();
                       string company = rawData.Split('-')[0];
                       string firstname = rawData.Split('-')[1];
                       string lastname = rawData.Split('-')[2];

                       ViewBag.Company = company;
                       ViewBag.FirstName = firstname;
                       ViewBag.LastName = lastname;
                   }
                   else
                   {
                       string company = Request.Form["company"];
                       string firstname = Request.Form["firstname"];
                       string lastname = Request.Form["lastname"];
                       string rawdata = string.Format("{0}-{1}-{2}", company, firstname, lastname);
                       HttpCookie cookieStep1 = new HttpCookie(COOKIE_DATA_STEP1, rawdata);
                       cookieStep1.Expires = COOKIE_EXPIRE;
                       Response.SetCookie(cookieStep1);
                   }


                    ViewBag.Tablets = Tablets;


                    return View("Step2");
                case 3:

                    if (Request.Cookies[COOKIE_DATA_STEP1] != null)
                    {
                        string rawData = Request.Cookies[COOKIE_DATA_STEP1].Value.ToString();
                        string company = rawData.Split('-')[0];
                        string firstname = rawData.Split('-')[1];
                        string lastname = rawData.Split('-')[2];

                        ViewBag.Company = company;
                        ViewBag.FirstName = firstname;
                        ViewBag.LastName = lastname;
                    }


                    if (Request.Cookies[COOKIE_DATA_STEP2] != null)
                    {
                        string rawData = Request.Cookies[COOKIE_DATA_STEP2].Value.ToString();
                        string tablet = rawData.Split('-')[0];
                        string casetablet = rawData.Split('-')[1];
                        string assurance = rawData.Split('-')[2];

                        ViewBag.Tablet = Tablets.Find(t => t.ID == int.Parse(tablet)).Name;
                        if (!String.IsNullOrEmpty(casetablet))
                            ViewBag.Case = true;
                        else
                            ViewBag.Case = false;

                        if (!String.IsNullOrEmpty(assurance))
                            ViewBag.Assurance = true;
                        else
                            ViewBag.Assurance = false;
                    }
                    else
                    {
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
                        string tablet = Request.Form["tablet"];
                        string casetablet = Request.Form["case"];
                        string assurance = Request.Form["assurance"];
                        string rawdata = string.Format("{0}-{1}-{2}", tablet, casetablet, assurance);
                        HttpCookie cookStep2 = new HttpCookie(COOKIE_DATA_STEP2, rawdata);
                        cookStep2.Expires = COOKIE_EXPIRE;
                        Response.SetCookie(cookStep2);
                    }


                    return View("Step3");
                default:
                    return RedirectToAction("New");
            }
        }

        public ActionResult Bestel()
        {
            Response.Cookies[COOKIE_NAME].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies[COOKIE_DATA_STEP1].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies[COOKIE_DATA_STEP2].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("New");
        }
    }
}