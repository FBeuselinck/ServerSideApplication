using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Oefening_1.Models
{
    public class StateModel
    {
        HttpContextBase _ctx;

        public StateModel(HttpContextBase ctx)
        {
            _ctx = ctx;
        }

        public void Save(string key, string value)
        {
            /*
            byte[] data = Encoding.ASCII.GetBytes(value);
            byte[] safeValue = MachineKey.Protect(data, GetMachineKeyPurpose(_ctx.User));

            string base64SafeData = Convert.ToBase64String(safeValue);
            _ctx.Response.Cookies.Add(new HttpCookie(key, base64SafeData));
            */
            
            _ctx.Session[key] = value;
        }

        public string Load(string key)
        {
            /*
            var cookie = _ctx.Request.Cookies[key];
            if (cookie != null)
            {
                byte[] safeData = Convert.FromBase64String(cookie.Value);
                byte[] decryptedData = MachineKey.Unprotect(safeData, GetMachineKeyPurpose(_ctx.User));
                return Encoding.ASCII.GetString(decryptedData);
            }
            return null;
            */

            return (string) _ctx.Session[key];
        }

        const string MachineKeyPurpose = "Oefening1:Username:{0}";
        const string Anonymous = "<anonymous>";

        string GetMachineKeyPurpose(IPrincipal user)
        {
            return String.Format(MachineKeyPurpose,
                user.Identity.IsAuthenticated ? user.Identity.Name : Anonymous);
        }
    }
}