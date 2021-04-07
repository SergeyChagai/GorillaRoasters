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
    public partial class RatingView : Image
    {
        public RatingView()
        {
            InitializeComponent();
            Rating = 1;
        }
        public static readonly BindableProperty RatingProperty =
           BindableProperty.Create
           (
               propertyName: nameof(Rating),
               returnType: typeof(int),
               declaringType: typeof(RatingView)
               );

        public int Rating
        {
            get => (int)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if(sender is RatingView ratingView)
            {
                Rating = (int)(e.TotalX / (Width / 5));
            }
        }
    }
}