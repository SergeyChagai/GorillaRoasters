using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GorillaRoasters.CustumViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RatingPopup : ContentView
    {
        public RatingPopup()
        {
            InitializeComponent();
            IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            IsVisible = false;
        }
    }
}