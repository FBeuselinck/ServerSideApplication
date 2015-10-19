using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSALabo1Demo1b.Web.Controllers
{
    public class TimeController : Controller
    {
        public ActionResult WhatTime(int? uur, int? min, int? sec)
        {
            if (uur == null || min == null || sec == null)
            {
                return View("Error");
            }
            ViewBag.Time = string.Format("{0}:{1}:{2}", uur, min, sec);
            return View();
        }

        public ActionResult WhatTime2()
        {
            if (String.IsNullOrEmpty(Request.QueryString["uur"]) ||
                String.IsNullOrEmpty(Request.QueryString["min"]) ||
                String.IsNullOrEmpty(Request.QueryString["sec"]))
            {
                return View("Error");
            }

            int uur, min, sec;

            int.TryParse(Request.QueryString["uur"], out uur);
            int.TryParse(Request.QueryString["min"], out min);
            int.TryParse(Request.QueryString["sec"], out sec);

            ViewBag.Time = string.Format("{0}:{1}:{2}", uur, min, sec);

            return View("WhatTime");
        }
    }
}
