using Dropbox.DataAccess;
using Dropbox.Models;
using Dropbox.Models.PresentationModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dropbox.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        [Authorize]
        public ActionResult File()
        {
            FileRegistrationVM overzicht = new FileRegistrationVM();
            overzicht.Me = FileRegistrationDA.getMijnBestanden(User.Identity.Name);
            if (User.IsInRole("Administrator"))
            {
                overzicht.Others = FileRegistrationDA.getAlleBestanden();
            }
            else
            {
                overzicht.Others = FileRegistrationDA.getBestandenToegang(User.Identity.Name);
            }


            return View(overzicht);
        }

        public FileResult Download(int? id)
        {
            List<FileRegistration> lijst = FileRegistrationDA.getMijnBestanden(User.Identity.Name);
            FileRegistration fileRegistration = FileRegistrationDA.GetFileRegistrationById(id.Value);

            if (!lijst.Contains(fileRegistration))
            {
                FileRegistrationDA.SaveLogs(fileRegistration);

                string path = Server.MapPath("/app_data/Uploads/");
                path += fileRegistration.FileName;
                return File(System.IO.File.ReadAllBytes(path),
                System.Net.Mime.MediaTypeNames.Application.Octet, fileRegistration.FileName);
            }
            else
            {
                return null;
            }
        }

        public ViewResult Delete(int? id)
        {            
            FileRegistration file = FileRegistrationDA.GetFileRegistrationById(id.Value);
            if(file.UserName == User.Identity.Name)
            {
                return View("Delete", file);
            }
            else
            {
                return View("Error");
            }

        }

        [HttpPost]
        public ViewResult Delete2(int? id)
        {
            FileRegistration file = FileRegistrationDA.GetFileRegistrationById(id.Value);    
            int affected = FileRegistrationDA.DeleteFile(id.Value);

            if(affected > 0)
            {
                string path = Server.MapPath("~/app_data/Uploads/");
                path += file.FileName;

                FileInfo bestand = new FileInfo(path);
                bestand.Delete();
            }

            FileRegistrationVM overzicht = new FileRegistrationVM();
            overzicht.Me = FileRegistrationDA.getMijnBestanden(User.Identity.Name);
            overzicht.Others = FileRegistrationDA.getBestandenToegang(User.Identity.Name);
            return View("File", overzicht);
        }

        public ViewResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return View("Error");
            }

            FileRegistration file = FileRegistrationDA.GetFileRegistrationById(id.Value);
            if (file.UserName == User.Identity.Name)
            {
                return View("Edit", file);
            }
            else
            {
                return View("Error");
            }
        }

        [Authorize]
        public ViewResult Edit2(FileRegistration file)
        {
            if (file.UserName == User.Identity.Name)
            {
                FileRegistrationDA.UpdateFile(file);
                FileRegistrationVM overzicht = new FileRegistrationVM();
                overzicht.Me = FileRegistrationDA.getMijnBestanden(User.Identity.Name);
                overzicht.Others = FileRegistrationDA.getBestandenToegang(User.Identity.Name);
                return View("File", overzicht);
            }
            else
            {
                return View("Error");
            }
        }

    }
}