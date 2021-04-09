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
            BindingContext = this;
            VisualStateManager.GoToState(BaseLayout, "Normal");
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(BaseLayout, "Selected");
        }
    }
}