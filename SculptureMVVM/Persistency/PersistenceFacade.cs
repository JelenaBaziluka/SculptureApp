using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using SculptureMVVM.Model;

namespace SculptureMVVM.Persistency
{
    class PersistenceFacade
    {
        const string ServerUrl = "http://localhost:3285";
        HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        //GetSculptures
      //  public async Task<List<Sculpture>> GetSculptures()
        public  List<Sculpture> GetSculptures()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Sculptures").Result;
                    //var response = await client.GetAsync("api/Sculptures");
                    if (response.IsSuccessStatusCode)
                    {
                        var sculptureList = response.Content.ReadAsAsync<IEnumerable<Sculpture>>().Result;
                        return sculptureList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                    // MessageDialog dialog = new MessageDialog(ex.Message);
                }
                return null;
            }

        }
        public void SaveSculpture(Sculpture sculpture)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(sculpture);
                    var response =
                        client.PostAsync("api/Sculptures", new StringContent(postBody, Encoding.UTF8, "application/json"))
                            .Result;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                    // MessageDialog dialog = new MessageDialog(ex.Message);
                }
            }
        }

    }
}
