using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zoekertjes.WebApp.Models;

namespace ZoerktjesDesktop
{
    public class WebserviceAccess
    {
        private const string URL = "http://localhost:64041/api";

        public async Task<List<Zoekertje>> Load()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/zoekertjemobile");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    string json = await response.Content.ReadAsStringAsync();
                    List<Zoekertje> result = JsonConvert.DeserializeObject<List<Zoekertje>>(json);
                    return result;
               }

                return null;
            }
        }
        public async Task<List<Categorie>> 	LoadCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/categorie");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Categorie> result = JsonConvert.DeserializeObject<List<Categorie>>(json);
                    return result;
                }

                return null;
            }
        }
        public async Task<List<Locatie>> LoadLocaties()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/locatie");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Locatie> result = JsonConvert.DeserializeObject<List<Locatie>>(json);
                    return result;
                }

                return null;
            }
        }
        public async Task<bool> AddZoekertje(Zoekertje newZoekertje)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/zoekertjemobile");
                string json = JsonConvert.SerializeObject(newZoekertje);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(json,Encoding.UTF8,"application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
