using Dropbox.DataAccess;
using Dropbox.Models;
using Dropbox.Models.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dropbox.Controllers
{
    [Authorize]
    public class ExternalUserController : Controller
    {
        public static ExternalUser user = new ExternalUser();
        public static List<ExternalUser> users = new List<ExternalUser>();

        public static ExternalUserVM OpvullenVM()
        {
            ExternalUserVM ExtUserVM = new ExternalUserVM();
            ExtUserVM.User = user;
            users = ExternalUserDA.GetUsers();
            ExtUserVM.Users = users;
            return ExtUserVM;
        }

        // GET: ExternalUser
        public ActionResult ExUser()
        {
            return View(OpvullenVM());
        }

        [HttpPost]
        public ActionResult ExUserToevoegen(ExternalUserVM model)
        {
            if (model.User == null)
                return View(OpvullenVM());

            int affected = ExternalUserDA.InsertExUser(model.User);

            if (affected > 0)
                return View("ExUser", OpvullenVM());
            else
                return View("Error");
        }
    }
}