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

namespace aicogestnew.Views.Vendors_Documents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VendorAlbaranes : ContentPage
    {
        private Vendor _mvendr;
        public VendorAlbaranes(Vendor _vendor)
        {
            InitializeComponent();
            _mvendr = _vendor;          
   
         
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView1.ItemsSource = await GetVendors(_mvendr.Codvendor);
            listView1.ItemTapped += ListitemTapped;
        }

        private async void ListitemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSe = e.Item as PurchaseHeader;    
        }
        public async Task<List<ShippingInvoiceHeader>> GetVendors(string codvendor)
        {
            {
                var credentials = new NetworkCredential("vabowl", "P3lvmt3n");
                var handler = new HttpClientHandler { Credentials = credentials };
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient(handler);
                List<ShippingInvoiceHeader> Model = null;


                //string url = uro + search;
                var response = await client.GetAsync("http://167.86.119.48:83/api/Shippinginvoiceheaders");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();

                    Model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShippingInvoiceHeader>>(jsonstring);

                    var albaranes = from m in Model
                                 select m;
                    albaranes.Where(s => s.CodVendor.Contains(codvendor.ToString()));
                    return albaranes.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

    }
}