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
        private Vendor _mvendr;
        public VendorGeneralPage(Vendor _vendor)
        {
            InitializeComponent();
            _mvendr = _vendor;

            lblCodProv.Text = _mvendr.Codvendor;
            lblNomProveedor.Text = _mvendr.VendorName;


        }
    }
}