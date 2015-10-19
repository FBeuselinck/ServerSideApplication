using Dropbox2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Dropbox2.DataAccess
{
    public class DAFileRegistration
    {
        private const string CONNECTIONSTRING= "DefaultConnection";
        public static int SaveFileRegistration(string fileName, string description, string userName){
            string sql= "INSERT INTO FileRegistration VALUES(@Description,@FileName,@UploadTime,@UserName,0)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Description", description);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@FileName", fileName);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@UploadTime", DateTime.Now);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@UserName", userName);
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2, par3, par4);


        }
        public static int SaveDownloaders(string user, int id)
        {
            string sql = "INSERT INTO FileUser VALUES(@FileId,@UserName)";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@FileId", id);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@UserName", user);
            return Database.InsertData(CONNECTIONSTRING, sql, par1, par2);


        }
        public static List<FileRegistration> LoadMyFiles()
        {
            List<FileRegistration> lijst = new List<FileRegistration>();
            string sql = "SELECT * FROM FileRegistration";
            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql);

            while (data.HasRows)
            {
                while (data.Read())
                {
                    lijst.Add(Create(data));

                }
                data.NextResult();
            }

            return lijst;

        }
        public static List<FileRegistration> LoadMyFiles(string user)
        {
            List<FileRegistration> lijst = new List<FileRegistration>();
            string sql = "SELECT * FROM FileRegistration WHERE UserName=@user";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@user", user);
            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql, par1);

            while (data.HasRows)
            {
                while (data.Read())
                {
                    lijst.Add(Create(data));
                    
                }
                data.NextResult();
            }

            return lijst;

        }
        public static List<FileRegistration> LoadMyFilesAccessTo()
        {
            List<FileRegistration> lijst = new List<FileRegistration>();
            string sql = "SELECT a.FileId,a.Description,a.FileName,a.UploadTime,a.UserName FROM FileRegistration as a INNER JOIN FileUser as b ON a.FileId=b.FileId";

            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql);

            while (data.HasRows)
            {
                while (data.Read())
                {
                    lijst.Add(Create(data));

                }
                data.NextResult();
            }

            return lijst;

        }
        public static List<FileRegistration> LoadMyFilesAccessTo(string user)
        {
            List<FileRegistration> lijst = new List<FileRegistration>();
            string sql = "SELECT a.FileId,a.Description,a.FileName,a.UploadTime,a.UserName FROM FileRegistration as a INNER JOIN FileUser as b ON a.FileId=b.FileId WHERE b.UserName=@user";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@user", user);
            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql, par1);

            while (data.HasRows)
            {
                while (data.Read())
                {
                    lijst.Add(Create(data));

                }
                data.NextResult();
            }

            return lijst;

        }
        public static FileRegistration LoadFileById(int id)
        {
            FileRegistration f = new FileRegistration();
            string sql = "SELECT a.FileId,a.Description,a.FileName,a.UploadTime,a.UserName FROM FileRegistration as a INNER JOIN FileUser as b ON a.FileId=b.FileId WHERE a.FileId=@id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql, par1);

            data.Read();

            f = Create(data);
            return f;
        }
        public static int DeleteFileById(int id)
        {
            int data;
            string sql = "DELETE FROM FileRegistration WHERE FileId=@id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            data = Database.ModifyData(CONNECTIONSTRING, sql, par1);

            return data;


        }


        private static FileRegistration Create(DbDataReader data)
        {
            return new FileRegistration()
            {
                FileId = (int)data["FileID"],
                Description = data[1].ToString(),
                FileName = data[2].ToString(),
                UploadTime = (DateTime)data[3],
                UserName = data[4].ToString()
            };
        }



        public static FileRegistration GetFileRegistationById(int id)
        {
            FileRegistration file =  new FileRegistration();
            string sql = "SELECT * FROM FileRegistration WHERE FileId=@id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql, par1);

           
                data.Read();
                file.FileName = data["FileName"].ToString();
                file.Description = data["Description"].ToString();
                file.FileId = (int)data["FileId"];
                file.UploadTime =(DateTime) data["UploadTime"];
                file.UserName = data["UserName"].ToString();


            return file;
        }
        public static FileUser GetFileUserById(int id)
        {
            FileUser file = new FileUser();
            string sql = "SELECT * FROM FileUser WHERE FileId=@id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql, par1);


            data.Read();
            file.FileId = (int)data["FileId"];
            file.UserName = data["UserName"].ToString();
  

            return file;
        }




        public static int UpdateFileById(int id,string description)
        {
            int data;
            string sql = "UPDATE FileRegistration SET Description=@des WHERE FileId=@id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@des", description);
            data = Database.ModifyData(CONNECTIONSTRING, sql, par1,par2);

            return data;
        }

        public static void UpdateDownload(int id)
        {
    

            //inladen
            int aantal = 0;
           
            string sql = "SELECT Downloaded FROM FileRegistration WHERE FileId=@id";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql, par1);


            data.Read();
            aantal= (int)data["Downloaded"];
            aantal++;

            //updaten
            string sql2 = "UPDATE FileRegistration SET Downloaded=@down WHERE FileId=@id";
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@id", id);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@down", aantal);
            Database.ModifyData(CONNECTIONSTRING, sql2, par2, par3);



        }

        public static int GetTotalDownload()
        {
            int aantal = 0;

            string sql = "SELECT sum(a.Downloaded) as som FROM FileRegistration as a";
            DbDataReader data = Database.GetData(CONNECTIONSTRING, sql);

            data.Read();
            aantal = (int)data["som"];
            return aantal;
        }
    }
}