using Dropbox.DataAccess;
using Dropbox.Models;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Dropbox.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Hier controleren we of een gebruiker al dan niet zal bestaan in de database. Indien de gebruiker niet bestaat dan zal de gebruiker moeten 
            // weigeren. Onderstaande code zal daarvoor zorgen.

            ExternalUser user = ExternalUserDA.CheckCredentials(context.UserName, context.Password);
            if (user == null)
            {
                context.Rejected();
                return Task.FromResult(0);
            }

            var id = new ClaimsIdentity(context.Options.AuthenticationType);
            id.AddClaim(new Claim("username", context.UserName));
            id.AddClaim(new Claim("role", "user"));

            context.Validated(id);
            return Task.FromResult(0);
        }
    }
}