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
    public partial class VendorAlbaranes : ContentPage
    {
        public VendorAlbaranes()
        {
            InitializeComponent();

            
            var a = ((Vendor)Parent.BindingContext).Codvendor;

           lblCodProv.Text = Title = a.ToString() ;
           lblNomProveedor.Text = ((Vendor)BindingContext).VendorName;
        }
        
    }
}