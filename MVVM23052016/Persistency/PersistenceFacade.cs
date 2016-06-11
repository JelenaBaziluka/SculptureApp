using MVVM23052016.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MVVM23052016.Persistency
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
        public List<Sculpture> GetSculptures()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Sculptures").Result;

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
        //public void DeleteSculpture(int sculp_Id)
        //{
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            string deleteUrl = "api/Sculptures" + sculp_Id;
        //            var response = client.DeleteAsync(deleteUrl).Result;
        //            if (response.IsSuccessStatusCode)
        //            {
        //                new MessageDialog("Succesfull delete");

        //            }
        //            else
        //            {
        //                new MessageDialog("Something went wrong,sculpture not deleted");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            new MessageDialog("Something went wrong,sculpture not deleted");
        //        }
        //    }
        //}

        public void DeleteSculpture(Sculpture SelectedSculpture)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string deleteUrl = "api/Sculptures/" + SelectedSculpture.Sculpture_Id;
                    var response = client.DeleteAsync(deleteUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        new MessageDialog("Succesfull delete");

                    }
                    else
                    {
                        new MessageDialog("Something went wrong,sculpture not deleted");
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog("Something went wrong,sculpture not deleted");
                }
            }
        }
        public void UpdateSculpture(Sculpture sculptureToUpdate)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    //we have to serialize the sculture object into json format
                    string jsonSculptureToUpdate = JsonConvert.SerializeObject(sculptureToUpdate);
                    //Create the content we want to send with the Http put request
                    StringContent content = new StringContent(jsonSculptureToUpdate, Encoding.UTF8, "Application/json");
                    //Using a Http Put Request we can update the sculpture number 3
                    var updateResponse = client.PutAsync("api/Sculptures/" + sculptureToUpdate.Sculpture_Id, content).Result;
                    var result = updateResponse.StatusCode;

                    //var response = client.GetAsync("api/Sculpture").Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    var sculptureList = response.Content.ReadAsAsync<IEnumerable<Sculpture>>().Result;
                    //    return sculptureList.ToList();
                    //}
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
          }
        //public List<Damage> GetAllDamages()
        //{
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            var response = client.GetAsync("api/sculptures").Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var DamageList = response.Content.ReadAsAsync<IEnumerable<Damage>>().Result;
        //                return DamageList.ToList();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            new MessageDialog(ex.Message).ShowAsync();
        //        }
        //        return null;
        //    }
        //}
     public void SaveDamage(Damage d)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    
                   // d.Sculpture = new Sculpture();
                    string newDamagejson = JsonConvert.SerializeObject(d);
                    //Create the content we will send in the Http post request 
                    var content = new StringContent(newDamagejson, Encoding.UTF8, "application/json");
                    var response2 = client.PostAsync("api/Damages", content).Result;
                                   if (response2.IsSuccessStatusCode)
                    {
                        //Success , Now we can get the sculpture by a Http post
                        new MessageDialog("Damage created").ShowAsync();
                    }
                }
                catch (Exception ex)
                {

                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
