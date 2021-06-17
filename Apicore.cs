using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SyndigoCoreAPIApp
{
    class com_beamsuntory_eim_integrations_syndigo_apicore
    {
        public static string baseURL = "https://api.uat.syndigo.com/";
            public static async Task<string> GetToken()
            {
                string token;
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), baseURL + "api/auth?username=BeamSuntory_API&secret=ZfY2xGDqCy1Qjgi33tSzhWO6KycJR1KATdv1wlfnZTI8/YLD7QlUOSjVQ03DRWVGB%2B86TZDuUh/lEugsHfKV/g%3D%3D"))
                    {
                        var response = await httpClient.SendAsync(request);

    //                    Console.WriteLine(response);

                        string result = await response.Content.ReadAsStringAsync();
                        JObject jObjToken = JObject.Parse(result);                 // Parse the object graph
                        token = jObjToken["Value"].ToString();       // Retrive value by key

      //                  Console.WriteLine(token);
                    }
                }
                return token;
            }

        private static async Task<dynamic> SearchProduct(string token,object Product)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), baseURL+"ui/product?skip=0&take=5000&includemetadata=true"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "EN " + token);

                    request.Content = new StringContent("\n{\n  \"DataOwner\": \"{b5447b40-a6a4-4c7e-890d-aaa891f8a845}\",\n  \"ProductsIds\": [\n    \"3105294e-72ab-94fc-9dab-d33422a0379c\"\n  ]\n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await client.SendAsync(request);
                    string result = await response.Content.ReadAsStringAsync();
                    var jSonResultObj = (JObject)JsonConvert.DeserializeObject(result);

                    // parse the response and return the data.

                    Console.WriteLine(jSonResultObj);
                    return (dynamic)response;
                }

            }
            
        }
        private static async Task<dynamic> CreateProduct(string token, Object product)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), baseURL+"/api/product/import?CompanyID={CompanyID}&templateId=00000000-0000-0000-0000-000000000000"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "EN " + token);

                    request.Content = new StringContent("\n{\n  \"ImportMode\": \"create\",\n  \"AllowDefaultAttributeMapping\": true,\n  \"ErrorMode\": \"Ignore\",\n  \"ProductAmbiguityHandling\": \"Error\",\n  \"AssetAmbiguityHandling\": \"Error\",\n  \"IdentifierValue\": \"AdamTighton0623202001\",\n  \"PackageType\": \"BaseUnit\"\n}\n");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    string result = await response.Content.ReadAsStringAsync();
                    var jSonResultObj = (JObject)JsonConvert.DeserializeObject(result);

                    // parse the response and return the data.

                    Console.WriteLine(jSonResultObj);
                    return (dynamic)response;
                }
            }
        }
        private static async Task<dynamic> UpdateeProduct(string token, Object product)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), baseURL + "/api/product/import?CompanyID={CompanyID}&templateId=00000000-0000-0000-0000-000000000000"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "EN " + token);

                    request.Content = new StringContent("\n{\n  \"ImportMode\": \"update\",\n  \"AllowDefaultAttributeMapping\": true,\n  \"ErrorMode\": \"Ignore\",\n  \"ProductAmbiguityHandling\": \"Error\",\n  \"AssetAmbiguityHandling\": \"Error\",\n  \"IdentifierValue\": \"AdamTighton0623202001\",\n  \"PackageType\": \"BaseUnit\"\n}\n");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    string result = await response.Content.ReadAsStringAsync();
                    var jSonResultObj = (JObject)JsonConvert.DeserializeObject(result);

                    // parse the response and return the data.

                    Console.WriteLine(jSonResultObj);
                    return (dynamic)response;
                }
            }
        }


    }
}
