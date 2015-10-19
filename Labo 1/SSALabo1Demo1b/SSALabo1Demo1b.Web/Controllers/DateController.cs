using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSALabo1Demo1b.Web.Controllers
{
    public class DateController : Controller
    {
        public ActionResult Today()
        {
            ViewBag.Today = DateTime.Now.ToString();
            return View();
        }

        public ActionResult Yesterday()
        {
            ViewBag.Yesterday = DateTime.Now.AddDays(-1).ToString();
            return View();
        }

        public ActionResult Tomorrow()
        {
            ViewBag.Tomorrow = DateTime.Now.AddDays(1);
            return View();
        }
        //
        // GET: /Date/

        public ActionResult Index()
        {
            return View();
        }

    }
}
