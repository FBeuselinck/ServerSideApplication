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
    public class CategorieController : ApiController
    {
        public List<Categorie> Get()
        {
            return Data.GetCategories();
        }
    }


}
