using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dropbox.Models
{
    public class FileRegistration
    {
        //FileId is een autonummer veld in de SQL server
        public int FileId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime UploadTime { get; set; }
        public string UserName { get; set; }
    }
}