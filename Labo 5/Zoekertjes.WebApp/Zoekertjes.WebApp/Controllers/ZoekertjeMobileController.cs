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
    public class ZoekertjeMobileController : ApiController
    {
        public List<Zoekertje> Get()
        {
            return Data.GetZoekertjes();
        }

        public Zoekertje Get(int id)
        {
            return Data.GetZoekertje(id);
        }

        public HttpResponseMessage Post(Zoekertje zoekertje)
        {
            if (zoekertje == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            try
            {
                Data.AddZoekertje(zoekertje);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
