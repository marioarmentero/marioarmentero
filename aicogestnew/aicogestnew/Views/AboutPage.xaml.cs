using aicogestnew.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aicogestnew.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            

           
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            

           // resu.SingleOrDefaultAsync(m => m.ID == id)

            frasedeldia.Text = "Mi frase traida de la base de datos";

        }
 
    }
}