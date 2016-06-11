using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using WebService2305;

namespace ConsoleSculp
{
    class Program
    {
        public static int menu()
        {
            Console.Write(
                 "1.List scultures" +
                "\n2.Create a new Sculpture " +
                "\n3.Add a new damage to an existing sculpture"+
                "\n4.Delete existing sculpture" +
                 "\nPlease enter your choice: "
                );
            return int.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            int choice = menu();
            Console.Clear();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                                }
                
                Console.WriteLine("Press any key to go to menu");
                Console.ReadKey();
                Console.Clear();
                choice = menu();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
               private static void Exercise4()
        {
            Console.WriteLine("Exercise 4");
            const string ServerUrl = "http://localhost:3285";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    Console.WriteLine("Enter sculpture ID which you want do delete:");
                    int sculpID = int.Parse(Console.ReadLine());
                    var response = client.DeleteAsync("api/sculptures/" + sculpID).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //IEnumerable<Sculpture> sculptureData = response.Content.ReadAsAsync<IEnumerable<Sculpture>>().Result;
                        Console.WriteLine("Succcesfull delete");
                    }
                    else
                    {
                        Console.WriteLine("Someting went wrong, hotel not deleted");
                    }
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error exercise 4" + ex.Message);
                }
            }
            Console.ReadLine();
        }

       
        //  Add a new damage to an existing sculpture
        private static void Exercise3()
        {
            Console.WriteLine("Exercise 3");
            const string ServerUrl = "http://localhost:3285";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    //Get the hotel fron the database
                    Console.Write("Enter Id of sculpture no for an existing sculpture:");
                    int sculpId = int.Parse(Console.ReadLine());
                    var response = client.GetAsync("api/Sculptures/" + sculpId).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Sculpture sculptureData = response.Content.ReadAsAsync<Sculpture>().Result;
                        if (sculptureData != null)
                        {
                            Console.WriteLine("Sculpture Id:{0}, Name: {1},Adress: {2}",sculptureData.Sculpture_Id,sculptureData.Sculpture_Name,sculptureData.Sculpture_Adress);
                          Damage d = new Damage();
                             d.Sculpture = sculptureData;
                           d.Sculpture_Id = sculptureData.Sculpture_Id;
                            Console.Write("Enter damage ID:");
                            d.Damage_Id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Damage name:");
                            d.Damage_Name = Console.ReadLine();
                            Console.Write("Enter Care name:");
                            d.Damage_Care = Console.ReadLine();
                            //The we need to serialize it
                            string newDamagejson = JsonConvert.SerializeObject(d);
                            //Create the content we will send in the Http post request 
                            var content = new StringContent(newDamagejson, Encoding.UTF8, "application/json");

                            var response2 = client.PostAsync("api/damages/PostDamageToExistingSculpture", content).Result;
                            Console.WriteLine("PostAsync");
                            Console.WriteLine("Status code " + response.StatusCode);

                            if (response2.IsSuccessStatusCode)
                            {
                                //Success , Now we can get the hotel by a Http post
                                Console.WriteLine("Damage created");
                                Console.WriteLine("Status code " + response2.StatusCode);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error exercise 3" + ex.Message);
                }
            }
            Console.ReadLine();
        }
        // Create a new Sculpture 
        private static void Exercise2()
        {
            Console.WriteLine("Exercise 2");
            const string ServerUrl = "http://localhost:3285";
            Console.WriteLine("Insert a new sculpture");
            Console.Write("Enter number of new sculpture:");
            int newSculpturelNo = int.Parse(Console.ReadLine());
            var newSculture = new Sculpture("Marmaid", "København strand", "ground", "Granite", "building");
            newSculture.Sculpture_Id= newSculpturelNo;
          string newSculptureJson = JsonConvert.SerializeObject(newSculture);
            var content =new StringContent(newSculptureJson, Encoding.UTF8,"application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync("api/sculptures", content).Result;
                Console.WriteLine("PostAsync");
                Console.WriteLine("Status code " + response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var responseSculpture = client.GetAsync("api/sculptures/" + newSculpturelNo).Result;
                    Console.WriteLine("GetAsync");
                    Console.WriteLine("Status code " + response.StatusCode);
                    if (responseSculpture.IsSuccessStatusCode)
                    {
                        newSculture = responseSculpture.Content.ReadAsAsync<Sculpture>().Result;
                        Console.WriteLine(newSculture.ToString());
                        var sculpture100 = responseSculpture.Content.ReadAsAsync<Sculpture>().Result;
                        Console.WriteLine(sculpture100.ToString());
                        Console.WriteLine("SculptureNo {0},{1}",
                            sculpture100.Sculpture_Id, sculpture100.Sculpture_Name);
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Error: " + response.ReasonPhrase);
                    //var errors = response.ModelState.Values.SelectMany(v => v.Errors);
                }
            }
        }
        // List sculptures
        private static void Exercise1()
        {
            Console.WriteLine("Exercise 1");
            const string ServerUrl = "http://localhost:3285";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpResponseMessage response = client.GetAsync("api/Sculptures").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        IEnumerable<Sculpture> stulptureData =
                            response.Content.ReadAsAsync<IEnumerable<Sculpture>>().Result;

                        foreach (var sculpture in stulptureData)
                        {
                           Console.WriteLine("{0},{1},{2}",sculpture.Sculpture_Id, sculpture.Sculpture_Name,sculpture.Sculpture_Adress);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error exercise 1" + ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
