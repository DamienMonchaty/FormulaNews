using FOne_MobileApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FOne_MobileApp.Persistence;

namespace FOne_MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
