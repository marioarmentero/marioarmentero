using aicogestnew.Models;
using aicogestnew.Services;
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
    public partial class registerPage : ContentPage
    {
        public registerPage()
        {
            InitializeComponent();
        }
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
              
                Login User = new Login();

                User.Email = txtEmail.Text;
                User.Password = txtPass.Text;

                Company services = new Company();

                var getLoginDetails = await services.CheckUserExists(txtEmail.Text);

                if (getLoginDetails)
                {
                    await DisplayAlert("Fallo en Registro", "Usuario existente en la Base de datos", "Okay", "Cancel");
                }
                else
                {

                    var GetRegister = await services.AddItemAsync(User);

                    if (GetRegister)
                    {
                        Application.Current.MainPage = new AppShell();
                    }


                }


            
       }
    }
}