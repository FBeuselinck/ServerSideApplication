using Dropbox.DataAccess;
using Dropbox.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dropbox.Controllers
{

    public class LogController : ApiController
    {
        [Authorize]
        [HttpGet]
        public ObservableCollection<FileLog> Get()
        {
            ObservableCollection<FileLog> logs = LogDA.GetLogs();
            return logs;
        }
    }
}
