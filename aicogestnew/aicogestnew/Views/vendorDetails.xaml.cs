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

           // VendorAlbaranes va = new VendorAlbaranes();
           // va.BindingContext = _myVendor;

            Children.Add(new VendorGeneralPage());
            Children.Add(new VendorAlbaranes());
            Children.Add(new VendorFacturasList());
            BindingContext = _myVendor;

            //               < local:VendorGeneralPage Title = "General" IconImageSource = "icon_feed.png" />

            //          < local:VendorFacturasList Title = "Facturas" IconImageSource = "icon_feed.png" />

            //           < local:VendorAlbaranes Title = "Facturas" IconImageSource = "icon_feed.png" />


        }
        public void OnNavigatedTo()
        { 
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
        }


    }
}