using Dropbox.Models;
using nmct.ba.template.api.Helper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Dropbox.DataAccess
{
    public class ExternalUserDA
    {
        private const string CONNECTIONSTRING = "DefaultConnection";

        public static List<ExternalUser> GetUsers()
        {
            List<ExternalUser> Users = new List<ExternalUser>();

            string sql = "SELECT * FROM ExternalUser";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);

            while(reader.Read())
            {
                ExternalUser user = new ExternalUser()
                {
                    Username = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    Blocked = (bool)reader["Blocked"]
                };

                Users.Add(user);
            }

            return Users;
        }


        public static int InsertExUser(ExternalUser user)
        {
            string sql = "INSERT INTO ExternalUser VALUES(@username,@password,@blocked)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@username", user.Username);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@password", user.Password);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@blocked", user.Blocked);
            DbParameter[] parameters = { par1, par2, par3 };
            int affected = Database.ModifyData(CONNECTIONSTRING, sql, parameters);
            return affected;
        }

        public static ExternalUser CheckCredentials(string Username, string Password)
        {
            ExternalUser USER = null;
            string sql = "SELECT * FROM ExternalUser WHERE Username=@username AND Password=@password";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@username", Username);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@password", Password);
            DbParameter[] parameters = { par1, par2 };

            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, parameters);

            while (reader.Read())
            {
                ExternalUser user = new ExternalUser()
                {
                    Username = reader["UserName"].ToString(),
                    Password = reader["Password"].ToString(),
                    Blocked = (bool)reader["Blocked"]
                };
                USER = user;
            }

            return USER;
        }
    }
}