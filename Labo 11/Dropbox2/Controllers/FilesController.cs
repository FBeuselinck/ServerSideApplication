using Dropbox2.DataAccess;
using Dropbox2.Hubs;
using Dropbox2.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Dropbox2.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        [HttpGet]
        public ActionResult Upload()
        {
            var context = new ApplicationDbContext();
   

            ViewBag.users = context.Users.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, string omschrijving, string[] wie)
        {
            HttpPostedFileBase file2 = Request.Files["file"];
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                int id = DAFileRegistration.SaveFileRegistration(fileName, omschrijving, User.Identity.Name);

                foreach (string item in wie)
                {
                    DAFileRegistration.SaveDownloaders(item.ToString(), id);
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Administrator"))
                {
                    List<FileRegistration> lijst = DAFileRegistration.LoadMyFiles();
                    ViewBag.Lijst = lijst;
                    List<FileRegistration> lijst2 = DAFileRegistration.LoadMyFilesAccessTo();
                    ViewBag.Lijst2 = lijst2;
                }
                else
                {
                    List<FileRegistration> lijst = DAFileRegistration.LoadMyFiles(User.Identity.Name);
                    ViewBag.Lijst = lijst;
                    List<FileRegistration> lijst2 = DAFileRegistration.LoadMyFilesAccessTo(User.Identity.Name);
                    ViewBag.Lijst2 = lijst2;
                }
               
                
            };

            


            return View();
        }
        [HttpGet]
        public ActionResult Download(int id)
        {
            FileRegistration file = DAFileRegistration.GetFileRegistationById(id);
            FileUser userAccesTo = DAFileRegistration.GetFileUserById(file.FileId);


            if (file.UserName == User.Identity.Name || userAccesTo.UserName==User.Identity.Name)
            {
                string path = Server.MapPath("~/App_Data/uploads/");
                path += file.FileName;

                DAFileRegistration.UpdateDownload(file.FileId);

                //hub updaten
                var hub = GlobalHost.ConnectionManager.GetHubContext<Counters>();
                hub.Clients.All.numberOfFilesDownloaded(DAFileRegistration.GetTotalDownload());

                return File(System.IO.File.ReadAllBytes(path), System.Net.Mime.MediaTypeNames.Application.Octet, file.FileName);
            }

           return RedirectToAction("Index");

            
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            FileRegistration file = DAFileRegistration.LoadFileById(id);
            if (file.UserName != User.Identity.Name)
            {
                return Content("Het lukt niet");
            }
            return View(file);
        }
        [HttpPost]
        public ActionResult Delete(FileRegistration file)
        {
            int i = file.FileId;

            DAFileRegistration.DeleteFileById(i);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id){
            FileRegistration file = DAFileRegistration.GetFileRegistationById(id);
            return View(file);
        }

        [HttpPost]
        public ActionResult Edit(FileRegistration file)
        {
            int i=DAFileRegistration.UpdateFileById(file.FileId,file.Description);

            return RedirectToAction("Index");
        }

    }
}