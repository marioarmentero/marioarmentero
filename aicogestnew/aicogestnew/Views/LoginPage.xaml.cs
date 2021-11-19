﻿using aicogestnew.Models;
using aicogestnew.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Mensaje", "Registro no implementado", "OK");
            //  throw new NotImplementedException();
            //  Navigation.PushAsync(new registerPage());
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            // var route = $"//{nameof(HomePage)}";
           // Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync("HomePage");
            // await Shell.Current.GoToAsync("AppShell");
            Login log = new Login
            {
                Email = txtEmail.Text,
                Password = txtPass.Text
            };
            if ((log.Email == "vabowl") & (log.Password == "vabowl"))
            {
                Application.Current.MainPage = new AppShell();
               
            }
            else
            {
                DisplayAlert("Error", "Contraseña Incorrecta", "OK");
            }



            //DisplayAlert("OK", "Subscripción realizada", "OK");
            // Navigation.PushAsync(new registerPage());
            //  throw new NotImplementedException();
        }

       
    }
}