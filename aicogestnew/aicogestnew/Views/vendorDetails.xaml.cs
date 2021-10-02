using aicogestnew.Models;
using aicogestnew.Views.Vendors_Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aicogestnew.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vendorDetails : TabbedPage
    {
        public vendorDetails(Vendor MiVendor)
        {
            InitializeComponent();
            var a = MiVendor.VendorName;

       
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
        }


    }
}