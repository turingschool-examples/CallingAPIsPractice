using System;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        // GitHub API endpoint
        string apiUrl = "https://api.github.com/orgs/dotnet/repos"; //CHANGE THIS URL

        // Create an instance of HttpClient
        using (HttpClient httpClient = new HttpClient())
        {
            // Set the User-Agent header required by GitHub API
            // The header provides information about the client making the request and helps the server identify the type of client, its operating system, and version information.
            // Postman sets this header automatically as something like PostmanRuntime/7.32.3
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("CallingAPIsPractice/1.0");

            // Send the GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            // Read the response content as a string
            string responseBody = await response.Content.ReadAsStringAsync();

            // Use the Json library to turn the string into an array
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(responseBody);
            Console.WriteLine(jsonResponse[0]["name"]); //CHANGE THE WAY YOU ACCESS THE RESPONSE DATA
        }
    }
}
