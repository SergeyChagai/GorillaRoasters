using GorillaRoasters.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GorillaRoasters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarWarsPage : ContentPage
    {
        public StarWarsPage()
        {
            InitializeComponent();
            BindingContext = new StarWarsPageVM();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ref var service = ref ((StarWarsPageVM)BindingContext).Service;
            switch(((Picker)sender).SelectedIndex)
            {
                case 0:
                    service = new Services.StarWarsSimpleService();
                    break;
                case 1:
                    service = new Services.StarWarsCoolService();
                    break;
            };
        }
    }
}