using aicogestnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace aicogestnew.Services
{
    class Company : ICompany
    {
        public async Task<Login> Login(string login, string password)
        {
            try
            {
                var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
                var handler = new HttpClientHandler { Credentials = credentials };
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient(handler);


                var response = await client.GetAsync("http://167.86.119.48:83/api/usuarios");

                var a = "123";

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    var Result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Login>>(jsonstring);

                    return Result.Single(x => x.Email == login & x.Password == password);


                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
           
            
        }
    }
}
