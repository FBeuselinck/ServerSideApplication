using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zoekertjes.WebApp.Models;

namespace Zoekertjes.WPF
{
    public class WebserviceAccess
    {
        private const string URL = "http://localhost:61600/api/";
        public static async Task<List<Zoekertje>> Load()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "webapi");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {

                    string json = await response.Content.ReadAsStringAsync();
                    List<Zoekertje> result = JsonConvert.DeserializeObject<List<Zoekertje>>(json);
                    return result;
                }
            }
            return null;
        }
    }
}
