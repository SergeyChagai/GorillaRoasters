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
        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            ViewModel = new MainPageViewModel();
            InitializeComponent();
            this.BindingContext = ViewModel;
        }
    }
}
