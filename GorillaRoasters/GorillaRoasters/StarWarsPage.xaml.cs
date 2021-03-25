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
    }
}