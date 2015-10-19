using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zoekertjes.WebApp.DataAccess;
using Zoekertjes.WebApp.Models;

namespace Zoekertjes.WebApp.Controllers
{
    public class LocatieController : ApiController
    {
        public List<Locatie> Get()
        {
            return Data.GetLocaties();
        }
    }
}
