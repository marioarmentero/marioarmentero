using aicogestnew.Models;
using aicogestnew.Services;
using aicogestnew.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.AttributeValidation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aicogestnew.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        private void BtnRegister_Clicked(object sender, EventArgs e)
        {      
            Navigation.PushAsync(new registerPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
           // var isValid = await this.ValidateAsync();

            Company services = new Company();
            var getLoginDetails = await services.CheckLoginIfExists(txtEmail.Text, txtPass.Text);

            if (getLoginDetails)
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }
    }

        

       
    
}