using aicogestnew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aicogestnew.Views.Vendors_Documents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VendorGeneralPage : ContentPage
    {
        public VendorGeneralPage()
        {
            InitializeComponent();
            lblCodProv.Text = Title = ((Vendor)BindingContext).Codvendor;
            lblNomProveedor.Text = ((Vendor)BindingContext).VendorName;


        }
    }
}