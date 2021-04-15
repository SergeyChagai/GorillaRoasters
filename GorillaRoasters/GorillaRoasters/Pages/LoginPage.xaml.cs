﻿using GorillaRoasters.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private async void UsernameButton_Clicked(object sender, EventArgs e)
        {

            _viewModel.Username = await DisplayPromptAsync("Username", "Enter your name", "OK", "Cancel", "Username", -1, Keyboard.Email, _viewModel.Username);
        }

        private async void PasswordButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.Password = await DisplayPromptAsync("Password", "Enter your password", "OK", "Cancel", "Password", -1, Keyboard.Text, _viewModel.Password);
        }
    }
}