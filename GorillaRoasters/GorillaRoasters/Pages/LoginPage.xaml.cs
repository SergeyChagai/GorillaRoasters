using GorillaRoasters.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GorillaRoasters.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginPageVM _viewModel;
        public LoginPage()
        {
            InitializeComponent();
            _viewModel = new LoginPageVM();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetLoginData();
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.SetLoginData();
            await Navigation.PopModalAsync();
        }


        //TO DO: write logic background for switch, data save must go if toggled only 
        private async void UsernameButton_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayPromptAsync("Username", "Enter your name", "OK", "Cancel", "Username", -1, Keyboard.Email, _viewModel.Username);
            _viewModel.Username = result;
            _viewModel.SetLoginData();
        }

        private async void PasswordButton_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayPromptAsync("Password", "Enter your password", "OK", "Cancel", "Password", -1, Keyboard.Text, _viewModel.Password);
            _viewModel.Password = result;
            _viewModel.SetLoginData();
        }

        private void Switch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RememberSwitch.ThumbColor = RememberSwitch.IsToggled ? Color.LightGreen : Color.LightGray;
        }
    }
}