using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace AgeHaystack
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "**API KEY**";
            var apiEndpoint = String.Format("https://api.haystack.ai/api/image/analyze?output=json&apikey={0}&model=age", apiKey);

            using (var client = new WebClient())
            {
                var image = File.ReadAllBytes(args[0]);
                var responseData = client.UploadData(apiEndpoint, "POST", image);
                var responseText = Encoding.UTF8.GetString(responseData);
                dynamic response = JsonConvert.DeserializeObject(responseText);
                var age = (String)response.people[0].age;

                Console.WriteLine(age);
            }
        }
    }
}
