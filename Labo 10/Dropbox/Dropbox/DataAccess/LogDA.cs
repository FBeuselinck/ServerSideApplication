using Dropbox.model;
using nmct.ba.template.api.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Dropbox.DataAccess
{
    public class LogDA
    {
        private const string CONNECTIONSTRING = "DefaultConnection";

        public static ObservableCollection<FileLog> GetLogs()
        {
            ObservableCollection<FileLog> lijst = new ObservableCollection<FileLog>();

            string sql = "SELECT * FROM DownloadLog";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);

            while (reader.Read())
            {
                FileLog log = new FileLog()
                {
                    FileId = Convert.ToInt32(reader["FileId"]),
                    FileName = reader["FileName"].ToString(),
                    Date = (DateTime)reader["DateTime"],
                    UserName = reader["UserName"].ToString()
                };

                lijst.Add(log);
            }

            return lijst;
        }
    }
}