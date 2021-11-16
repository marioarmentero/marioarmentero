using aicogestnew.ViewModels;
using aicogestnew.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace aicogestnew
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(PageVendors), typeof(PageVendors));
           
            Routing.RegisterRoute(nameof(Contactos), typeof(Contactos));
            Routing.RegisterRoute(nameof(vendorDetails), typeof(vendorDetails));
            Routing.RegisterRoute(nameof(ListProductView), typeof(ListProductView));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
