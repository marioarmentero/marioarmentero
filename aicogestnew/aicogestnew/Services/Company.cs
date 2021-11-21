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
    public class Company : ICompany
    {
        RestClient<Login> _restClient = new RestClient<Login>();

        public async Task<bool> AddItemAsync(Login _usuario)
        {
            var check = await _restClient.LoginAdd(_usuario);
            return check;           
        }       
        public async Task<bool> CheckLoginIfExists(string username, string password)
        {
            var check = await _restClient.checkLogin(username, password);
            return check;
        }
        public async Task<bool> CheckUserExists(string login)
        {
            var check = await _restClient.checkUser(login);
            return check;
        }
    }
}
