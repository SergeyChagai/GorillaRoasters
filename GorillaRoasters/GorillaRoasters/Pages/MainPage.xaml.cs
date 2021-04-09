using GorillaRoasters.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GorillaRoasters.Models;

namespace GorillaRoasters
{
    public partial class MainPage : ContentPage
    {
        public MainPageVM ViewModel { get; set; }

        public MainPage()
        {
            ViewModel = new MainPageVM();
            InitializeComponent();
            BindingContext = ViewModel;
            
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//starWarsPage");
        }

        private async void AnimateButton_Clicked(object sender, EventArgs e)
        {
            await AnimateButton.RotateTo(360, 1000);
        }

        private void OnAddToFavoriteButtonClicked(object sender, EventArgs e)
        {
            RatingPopup.IsVisible = true;
        }

       
    }
}
