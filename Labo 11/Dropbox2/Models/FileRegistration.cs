using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dropbox2.Models
{
    public class FileRegistration
    {
        public int FileId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime UploadTime { get; set; }
        public string UserName { get; set; }
    }
}