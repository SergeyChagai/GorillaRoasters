using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GorillaRoasters.Droid.Effects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("TileMode")]
[assembly: ExportEffect(typeof(ButtonFocusedEffect), nameof(ButtonFocusedEffect))]

namespace GorillaRoasters.Droid.Effects
{
    public class ButtonFocusedEffect : PlatformEffect
    {
        private Android.Graphics.Drawables.RippleDrawable _gradient;
        protected override void OnAttached()
        {
            _gradient = (Android.Graphics.Drawables.RippleDrawable)Control.Background;
            Control.SetOutlineSpotShadowColor(Android.Graphics.Color.Transparent);
        }

        protected override void OnDetached()
        {
        }
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args?.PropertyName == "IsPressed")
            {
                if (((Xamarin.Forms.Button)Element).IsPressed)
                {
                    Control.SetBackgroundColor(Android.Graphics.Color.Aquamarine);
                }
                else
                    Control.SetBackground(_gradient);
                
            }
        }
    }
}