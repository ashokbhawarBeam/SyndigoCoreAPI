using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SyndigoCoreAPIApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetProductAsync(args).GetAwaiter().GetResult();
            Console.ReadLine();
        }

        static async Task GetProductAsync(string[] args)
        {

            // this will hold the Access Token returned from the server.
            string accessToken = null;
            Console.WriteLine("Getting token");
            accessToken = await GetToken();
            Console.WriteLine(accessToken != null ? "Got Token" : "No Token found");
            await SearchProduct(accessToken);
            Console.WriteLine("All Done");
        }
        
    }
}
