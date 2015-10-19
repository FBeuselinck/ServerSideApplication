using Dropbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Dropbox.DataAccess;

namespace Dropbox.Controllers
{
    [Authorize]
    public class UploadController : Controller
    {
        // GET: Upload
        [HttpGet]
        public ActionResult Upload()
        {
            List<SelectListItem> users = getSelectList();
            //aanmaken nieuw model
            Upload nieuweUpload = new Upload();
            nieuweUpload.Users = users;
 
            return View(nieuweUpload);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, string description, string[] users)
        {
            // 3 parameters 
            // ==> HttpPostedFileBase ==> dit is de file die je wenst op te laden
            // ==> description is de omschrijving
            // ==> string[] wie zal een array van geselecteerde gebruikers zijn
            if(file != null && file.ContentLength > 0)
            {
                string filenaam = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/app_data/uploads"), filenaam);
                file.SaveAs(path);
                int id = FileRegistrationDA.SaveFileRegistration(filenaam, description, User.Identity.Name);

                if(users != null)
                {
                    foreach(string user in users)
                    {
                        FileRegistrationDA.SaveDownloaders(user, id);
                    }
                }

            }
            return RedirectToAction("Upload");
        }




        public List<SelectListItem> getSelectList()
        {
            // ophalen van de gebruikers, dit kun je ophalen via de ApplicationDbContext
            var context = new ApplicationDbContext();
            List<ApplicationUser> users = context.Users.ToList();

            List<SelectListItem> items = new List<SelectListItem>();

            foreach(ApplicationUser user in users)
            {
                items.Add(new SelectListItem() { Value = user.UserName, Text = user.Name + "-" + user.FirstName });
            }

            return items;
        }
    }
}