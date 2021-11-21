using aicogestnew.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aicogestnew.Services
{
    public interface ICompany
    {       
       Task<bool> CheckLoginIfExists(string login, string password);
        Task<bool> CheckUserExists(string login);
        Task<bool> AddItemAsync(Login _usuario);
    }
}
