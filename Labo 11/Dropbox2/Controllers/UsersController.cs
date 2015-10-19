using Dropbox2.DataAccess;
using Dropbox2.Models;
using Dropbox2.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dropbox2.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            PMExternalUser PMUser = new PMExternalUser()
            {
                ExternalUser= new ExternalUser(),
                Lijst=DAExternalUser.LoadUsers()
            };
            return View(PMUser);
        }

        [HttpPost]
        public ActionResult Index(PMExternalUser user)
        {
            int result = DAExternalUser.Insert(user.ExternalUser.Username, user.ExternalUser.Password);

            return RedirectToAction("Index") ;
        }



    }
}