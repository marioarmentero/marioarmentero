using aicogestnew.Services;
using aicogestnew.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aicogestnew
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<Company>();

            //MainPage = new AppShell();
            MainPage = new LoginShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
