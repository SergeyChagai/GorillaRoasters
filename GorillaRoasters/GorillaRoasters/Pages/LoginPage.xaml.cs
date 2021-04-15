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

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


        //TO DO: write logic background for switch, data save must go if toggled only 
        private async void UsernameButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.Username = await SecureStorage.GetAsync(nameof(_viewModel.Username));
            var result = await DisplayPromptAsync("Username", "Enter your name", "OK", "Cancel", "Username", -1, Keyboard.Email, _viewModel.Username);
            await SecureStorage.SetAsync(nameof(_viewModel.Username), result == null ? "" : result);
        }

        private async void PasswordButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.Password = await SecureStorage.GetAsync(nameof(_viewModel.Password));
            var result = await DisplayPromptAsync("Password", "Enter your password", "OK", "Cancel", "Password", -1, Keyboard.Text, _viewModel.Password);
            await SecureStorage.SetAsync(nameof(_viewModel.Password), result == null ? "" : result);
        }

        private void Switch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RememberSwitch.ThumbColor = RememberSwitch.IsToggled ? Color.LightGreen : Color.LightGray;
        }
    }
}