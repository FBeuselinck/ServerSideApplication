using Dropbox2.DataAccess;
using Dropbox2.Models;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Dropbox2.Providers
{
    public class SimpleAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            ExternalUser user = DAExternalUser.LoadUsers(context.UserName, context.Password);
            if (user==null)
            {
                context.Rejected();
                return Task.FromResult(0);
            }

            ClaimsIdentity claims = new ClaimsIdentity(context.Options.AuthenticationType);
            claims.AddClaim(new Claim("Username", context.UserName));
            claims.AddClaim(new Claim("Password", context.Password));
            context.Validated(claims);
            return Task.FromResult(0);
            
        }
    }
}