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
        public LoginPage()
        {
            InitializeComponent();
            VisualStateManager.GoToState(LoginButton, "NoActive");
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(LoginButton, "Active");
        }
    }
}