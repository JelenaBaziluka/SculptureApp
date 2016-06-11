using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WebServiceDemo;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace SculpConsole
{
    class Program
    {
        public static int menu()
        {
            Console.Write(
                 "1.List scultures" +
                "\n2.Create a new Sculpture with materials" +
                "\n3.Add a new damage to an existing sculpture" +
                "\n4.List all notes for a specific sculpture" +
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
        //List all notes for a specific sculpture
        private static void Exercise4()
        {
            throw new NotImplementedException();
        }
      //  Add a new damage to an existing sculpture"
        private static void Exercise3()
        {
            throw new NotImplementedException();
        }
       // Create a new Sculpture with materials
        private static void Exercise2()
        {
            throw new NotImplementedException();
        }
       // List sculptures
        private static void Exercise1()
        {
            Console.WriteLine("Exercise 1");
            const string ServerUrl = "http://localhost:18842";
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
                            Console.WriteLine(sculpture);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error exercise 1"+ ex.Message);
                }
            }
            Console.ReadLine();
        }

     
    }
   
}

