using GorillaRoasters.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GorillaRoasters
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ShellPage();
            MainPage.Navigation.PushModalAsync(new LoginPage());
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
