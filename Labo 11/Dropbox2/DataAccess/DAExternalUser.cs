using Dropbox2.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Dropbox2.DataAccess
{
    public class DAExternalUser
    {
        private const string CONNECTIONSTRING = "DefaultConnection";
        public static int Insert(string username, string password)
        {
            string sql = "INSERT INTO ExternalUsers(Username,Password,Blocked) VALUES(@Username,@Password,@Blocked)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Username", username);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Password", password);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Blocked", 0);
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3);
        }

        public static List<ExternalUser> LoadUsers()
        {
            List<ExternalUser> users = new List<ExternalUser>();
            string sql = "SELECT * FROM ExternalUsers";
            DbDataReader reader= Database.GetData(CONNECTIONSTRING, sql);

            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    users.Add(new ExternalUser()
                    {
                        Id=(int)reader["ID"],
                        Username=reader["Username"].ToString(),
                        Password=reader["Password"].ToString(),
                        Blocked=(bool)reader["Blocked"]
                    });
                }
                reader.NextResult();
            }
            return users;

        }

        public static ExternalUser LoadUsers(string username, string password)
        {
            List<ExternalUser> users = new List<ExternalUser>();
            string sql = "SELECT * FROM ExternalUsers WHERE Username=@Username AND Password=@Password";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "Password", password);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "Username", username);

            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);

            reader.Read();
            return new ExternalUser()
            {
                Id = (int)reader["ID"],
                Username = reader["Username"].ToString(),
                Password = reader["Password"].ToString(),
                Blocked = (bool)reader["Blocked"]
            };

        }
    }
}