using Dropbox.Models;
using nmct.ba.template.api.Helper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Dropbox.DataAccess
{
    public class FileRegistrationDA
    {
        private const string CONNECTIONSTRING = "DefaultConnection";
        
        public static int SaveFileRegistration(string fileName, string description, string userName)
        {
            string sql = "INSERT INTO FileRegistration VALUES(@Description, @FileName, @UploadTime, @UserName)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Description" , description);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@FileName" , fileName );
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@UploadTime" , DateTime.Now);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@UserName" , userName);
            DbParameter[] parameters = { par1,par2,par3, par4}; 
            return Database.InsertData(CONNECTIONSTRING,sql,parameters);
        }

        public static void SaveDownloaders(string user, int fileId)
        {
            string sql = "INSERT INTO FileUser VALUES(@FileId, @Username)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", fileId);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Username", user);
            DbParameter[] parameters = { par1, par2 };
            Database.InsertData(CONNECTIONSTRING, sql, parameters);
        }

        public static List<FileRegistration> getMijnBestanden(string ingelogdeUser)
        {
            List<FileRegistration> files = new List<FileRegistration>();

            string sql = "SELECT * FROM FileRegistration WHERE UserName=@username";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@username", ingelogdeUser);
            DbParameter[] parameters = { par1 };
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, parameters);

            while (reader.Read())
            {
                FileRegistration bestand = new FileRegistration()
                {
                    FileId = Convert.ToInt32(reader["FileId"]),
                    Description = reader["Description"].ToString(),
                    FileName = reader["FileName"].ToString(),
                    UploadTime = Convert.ToDateTime(reader["UploadTime"]),
                    UserName = reader["UserName"].ToString()
                };

                files.Add(bestand);
            }

            return files;

        }

        public static List<FileRegistration> getBestandenToegang(string ingelogdeUser)
        {

            List<FileRegistration> files = new List<FileRegistration>();

                // SELECT column_name(s)
                //FROM table1
                //INNER JOIN table2
                //ON table1.column_name=table2.column_name;


            string sql = "SELECT * FROM FileRegistration INNER JOIN FileUser ON FileRegistration.FileId = FileUser.FileId WHERE FileUser.UserName = @username";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@username", ingelogdeUser);
            DbParameter[] parameters = { par1 };
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, parameters);

            while (reader.Read())
            {
                FileRegistration bestand = new FileRegistration()
                {
                    FileId = (int)reader["FileId"],
                    Description = reader["Description"].ToString(),
                    FileName = reader["FileName"].ToString(),
                    UploadTime = Convert.ToDateTime(reader["UploadTime"]),
                    UserName = reader["UserName"].ToString()
                };

                files.Add(bestand);
            }

            return files;
        }

        public static List<FileRegistration> getAlleBestanden()
        {

            List<FileRegistration> files = new List<FileRegistration>();

            // SELECT column_name(s)
            //FROM table1
            //INNER JOIN table2
            //ON table1.column_name=table2.column_name;


            string sql = "SELECT * FROM FileRegistration";
            DbParameter[] parameters = null;
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, parameters);

            while (reader.Read())
            {
                FileRegistration bestand = new FileRegistration()
                {
                    FileId = (int)reader["FileId"],
                    Description = reader["Description"].ToString(),
                    FileName = reader["FileName"].ToString(),
                    UploadTime = Convert.ToDateTime(reader["UploadTime"]),
                    UserName = reader["UserName"].ToString()
                };

                files.Add(bestand);
            }

            return files;
        }

        public static FileRegistration GetFileRegistrationById(int id)
        {
            FileRegistration nieuw = new FileRegistration();

            string sql = "SELECT * FROM FileRegistration WHERE FileId=@fileId";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@fileId", id);
            DbParameter[] parameters = { par1 };
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql, parameters);

            while (reader.Read())
            {
                FileRegistration bestand = new FileRegistration()
                {
                    FileId = (int)reader["FileId"],
                    Description = reader["Description"].ToString(),
                    FileName = reader["FileName"].ToString(),
                    UploadTime = Convert.ToDateTime(reader["UploadTime"]),
                    UserName = reader["UserName"].ToString(),
                };

                nieuw = bestand;
            }

            return nieuw;
        }


        public static int DeleteFile(int id)
        {
            string sql = "DELETE FROM FileRegistration WHERE FileId=@fileId";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@fileId", id);
            DbParameter[] parameters = { par1 };
            int affected = Database.ModifyData(CONNECTIONSTRING, sql, parameters);

            return affected;
        }

        public static void UpdateFile(FileRegistration file)
        {
            string sql = "UPDATE FileRegistration SET Description=@description WHERE FileId=@id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@description", file.Description);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@id", file.FileId);
            DbParameter[] parameters = { par1, par2 };
            int affected = Database.ModifyData(CONNECTIONSTRING, sql, parameters);
        }

        public static void SaveLogs(FileRegistration file)
        {
            string sql = "INSERT INTO DownloadLog VALUES(@fileId, @fileName, @datetime, @username)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@fileId", file.FileId);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@fileName", file.FileName);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@datetime", DateTime.Now);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@username", file.UserName);
            DbParameter[] parameters = { par1, par2, par3, par4 };
            Database.ModifyData(CONNECTIONSTRING, sql, parameters);
        }
    }
}