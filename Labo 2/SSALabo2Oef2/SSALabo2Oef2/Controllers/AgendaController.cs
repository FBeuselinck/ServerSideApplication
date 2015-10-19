using SSALabo2Oef2.PresentationModels;
using SSALabo2Oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oefening_2;

namespace SSALabo2Oef2.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Agenda
        public ActionResult Show()
        {
            PMAgenda pm = new PMAgenda();
            pm.Slot1 = Data.GetSessions(1);
            pm.Slot2 = Data.GetSessions(2);
            pm.Slot3 = Data.GetSessions(3);
            return View(pm);
        }

        public ActionResult Detail(int? id)
        {
            if(id == null || id == 0)
            {
                return RedirectToAction("Show");
            }
            
            Session s = Data.GetSession((int) id);
            return View(s);


        }
    }
}