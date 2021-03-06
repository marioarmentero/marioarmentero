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
    public partial class CustomerPage : ContentPage
    {
        public CustomerPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView1.ItemsSource = await GetVendors();
            listView1.ItemTapped += ListitemTapped;
        }

        private async void ListitemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSe = e.Item as Customer ;
           // await Navigation.PushAsync(new vendorDetails(itemSe), true);
        }

        public async Task<List<Customer>> GetVendors()
        {
            {
                var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
                var handler = new HttpClientHandler { Credentials = credentials };
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient(handler);
                List<Customer> Model = null;
                // string uro = new Uri(http://167.86.119.48:83/api/vendors);  // 1 URL de Search           

                //string url = uro + search;
                var response = await client.GetAsync("http://167.86.119.48:83/api/customers");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    Model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(jsonstring);

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