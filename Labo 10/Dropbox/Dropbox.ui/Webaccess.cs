using Dropbox.model;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thinktecture.IdentityModel.Client;

namespace Dropbox.ui
{
    public class Webaccess : ObservableObject
    {
        private const string URL = "http://localhost:45482/";
        public static TokenResponse token = null;

        public TokenResponse GetToken(string userName, string password)
        {
            OAuth2Client client = new OAuth2Client(new Uri("http://localhost:45482/token"));
            return client.RequestResourceOwnerPasswordAsync(userName, password).Result;
        }

        private ObservableCollection<FileLog> _lijstLogs;

        public ObservableCollection<FileLog> LijstLogs
        {
            get { return _lijstLogs; }
            set { _lijstLogs = value;
            OnPropertyChanged("LijstLogs");
            }
        }
        


        
        public ICommand InlogCommand
        {
            get { return new RelayCommand(Login); }
        }

        public async void Login()
        {
            token = GetToken(UserName, Password);

            if(!token.IsError)
            {
                LijstLogs = await GetLogs(token.AccessToken);
            }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value;
            OnPropertyChanged("UserName");
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }


        public async Task<ObservableCollection<FileLog>> GetLogs(string token)
        {
            string url = URL + "api/log";
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(token);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    LijstLogs = JsonConvert.DeserializeObject<ObservableCollection<FileLog>>(json);
                }
            }

            return LijstLogs;

        }
    }
}
