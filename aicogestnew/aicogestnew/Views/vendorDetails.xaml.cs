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
        public Vendor _myVendor;
        public vendorDetails(Vendor MiVendor)
        {
            InitializeComponent();

            _myVendor = MiVendor;

             VendorAlbaranes va = new VendorAlbaranes(_myVendor);
            
            Children.Add(new VendorGeneralPage(_myVendor));
            Children.Add(va);
            Children.Add(new VendorFacturasList(_myVendor));
            //Children.Add(new PageVendors());


        }      
        protected async override void OnAppearing()
        {
            base.OnAppearing();            
        }


    }
}