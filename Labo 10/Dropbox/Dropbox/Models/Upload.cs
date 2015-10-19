using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dropbox.Models
{
    public class Upload
    {
        public string Omschrijving { get; set; }
        public List<SelectListItem> Users { get; set; }
        public string Bestand { get; set; }
    }
}