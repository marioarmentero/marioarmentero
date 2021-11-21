using aicogestnew.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aicogestnew.Services
{
    public interface ICompany
    {
       Task<Login> Login(string login, string password);
       Task<bool> CheckLoginIfExists(string login, string password);
    }
}
