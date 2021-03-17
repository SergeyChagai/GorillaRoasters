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
        public StartPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            ViewModel = new StartPageViewModel();
            InitializeComponent();
            this.BindingContext = ViewModel;
        }

        private void OnNextButtonClick(object sender, EventArgs e)
        {
            ViewModel.GoToNext();
        }
    }
}
