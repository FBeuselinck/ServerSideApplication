using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dropbox.Models.PresentationModels
{
    public class FileRegistrationVM
    {
        public List<FileRegistration> Me { get; set; }
        public List<FileRegistration> Others { get; set; }
        public FileRegistration labels { get; set; }
    }
}