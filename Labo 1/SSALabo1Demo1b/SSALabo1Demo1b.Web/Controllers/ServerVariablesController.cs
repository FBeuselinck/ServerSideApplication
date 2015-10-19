using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSALabo1Demo1b.Web.Controllers
{
    public class ServerVariablesController : Controller
    {
        //
        // GET: /ServerVariables/

        public ActionResult Index()
        {
            //ViewBag.Vars = Request.ServerVariables;
            return View(Request.ServerVariables);
        }

    }
}
