using aicogestnew.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace aicogestnew.Services
{
    public class RestClient<T>
    {
     
        public async Task<bool> checkLogin(string username, string password)
        {
            var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
            var handler = new HttpClientHandler { Credentials = credentials };
            HttpClient client = new System.Net.Http.HttpClient(handler);
           
            string url = "http://167.86.119.48:83/api/Usuarios/api/UserCredentials/username="+username+"/password="+password;
                          
            var response = await client.GetAsync(url);

            return response.IsSuccessStatusCode; // return either true or false

            
        }
    }
}
