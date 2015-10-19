using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropbox.model
{
    public class FileLog
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public DateTime Date{ get; set; }
        public string UserName { get; set; }
    }
}
