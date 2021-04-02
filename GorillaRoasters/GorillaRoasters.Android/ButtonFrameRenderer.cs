using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GorillaRoasters.CustumViews;
using GorillaRoasters.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(ButtonFrame), typeof(ButtonFrameRenderer))]
namespace GorillaRoasters.Droid
{
    public class ButtonFrameRenderer : FrameRenderer
    {
        public ButtonFrameRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e?.NewElement == null) return;
            Control.Elevation = 0f;
            Control.TranslationZ = 30f;
        }
    }
}