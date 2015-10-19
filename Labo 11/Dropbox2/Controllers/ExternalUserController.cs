using Dropbox2.DataAccess;
using Dropbox2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dropbox2.Controllers
{
    public class ExternalUserController : ApiController
    {
        public List<ExternalUser> Get()
        {
            return DAExternalUser.LoadUsers();
        }
    }
}
