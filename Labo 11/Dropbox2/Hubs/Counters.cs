using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Dropbox2.DataAccess;

namespace Dropbox2.Hubs
{
    public class Counters : Hub
    {
        public void getDownloadFiles()
        {
            int aantal = DAFileRegistration.GetTotalDownload();
            Clients.All.numberOfFilesDownloaded(aantal);
        }
    }
}