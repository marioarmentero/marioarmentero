using aicogestnew.Models;
using Newtonsoft.Json;
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
            var client = GetCliente();
            string url = "http://167.86.119.48:83/api/Usuarios/api/UserCredentials/username="+username+"/password="+password;                          
            var response = await client.GetAsync(url);
            return response.IsSuccessStatusCode; 
            
        }

        public async Task<bool> checkUser(string username)
        {
            // var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
            // var handler = new HttpClientHandler { Credentials = credentials };
            // HttpClient client = new System.Net.Http.HttpClient(handler);
            var client = GetCliente();
            string url = "http://167.86.119.48:83/api/Usuarios/api/UserExists/username=" + username;
            var response = await client.GetAsync(url);
            return response.IsSuccessStatusCode; 

        }

        private HttpClient GetCliente()
        {
            var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
            var handler = new HttpClientHandler { Credentials = credentials };
            HttpClient client = new System.Net.Http.HttpClient(handler);
            return client;
        }
        public async Task<bool> LoginAdd(Login _login)
        {
            //  var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
            // var handler = new HttpClientHandler { Credentials = credentials };
            //HttpClient client = new System.Net.Http.HttpClient(handler);
            var client = GetCliente();
            string url = "http://167.86.119.48:83/api/Usuarios";
            var json=JsonConvert.SerializeObject(_login);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = null;
            response = await client.PostAsync(url, content);
            
            return response.IsSuccessStatusCode;          

        }
    }
}
