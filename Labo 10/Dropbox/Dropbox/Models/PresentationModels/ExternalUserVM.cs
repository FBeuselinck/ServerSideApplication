using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dropbox.Models.PresentationModels
{
    public class ExternalUserVM
    {
        public ExternalUser User { get; set; }
        public List<ExternalUser> Users { get; set; }
    }
}