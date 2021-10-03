using aicogestnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aicogestnew.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Empresas : ContentPage
    {
        public Empresas()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView1.ItemsSource = await GetVendors();
   
        }
        public async Task<List<Empresa>> GetVendors()
        {
            {
                var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
                var handler = new HttpClientHandler { Credentials = credentials };
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient(handler);
                List<Empresa> Model = null;


                //string url = uro + search;
                var response = await client.GetAsync("http://167.86.119.48:83/api/empresas");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    Model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Empresa>>(jsonstring);

                   
                    return Model;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}