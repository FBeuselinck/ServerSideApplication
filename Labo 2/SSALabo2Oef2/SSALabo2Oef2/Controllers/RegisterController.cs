using Oefening_2;
using SSALabo2Oef2.Models;
using SSALabo2Oef2.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSALabo2Oef2.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            PMRegistration pmr = new PMRegistration();
            pmr.NewRegistration = new Registration();
            pmr.Slot1 = new SelectList(Data.GetSessions(1),"Id","Name");
            pmr.Slot2 = new SelectList(Data.GetSessions(2), "Id", "Name");
            pmr.Slot3 = new SelectList(Data.GetSessions(3), "Id", "Name");
            pmr.Organizations = new SelectList(Data.GetOrganizations(),"Id","Name");
            return View(pmr);
        }

        [HttpPost]
        public ActionResult Index(PMRegistration pmr)
        {

            if (!ModelState.IsValid)
            {
                return View(pmr);
            }
            else
            {
                pmr.NewRegistration.Slot1 = Data.GetSession(int.Parse(pmr.NewRegistration.Slot1)).Name;
                pmr.NewRegistration.Slot2 = Data.GetSession(int.Parse(pmr.NewRegistration.Slot2)).Name;
                pmr.NewRegistration.Slot3 = Data.GetSession(int.Parse(pmr.NewRegistration.Slot3)).Name;
                pmr.NewRegistration.Organization = Data.GetOrganization(int.Parse(pmr.NewRegistration.Organization)).Name;
                return View("Details", pmr.NewRegistration);
            }
            
        }
    }
}