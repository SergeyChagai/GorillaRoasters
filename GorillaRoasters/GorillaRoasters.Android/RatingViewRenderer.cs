using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GorillaRoasters.CustumViews;
using GorillaRoasters.Droid;
using System;
using System.Security.Policy;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(RatingView), typeof(RatingViewRenderer))]
namespace GorillaRoasters.Droid
{
    public class RatingViewRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<RatingView, ImageView>
    {
        public RatingViewRenderer(Context context) : base(context)
        {
            SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            var segment = Width / 5;
            RectF rect = new RectF(0, 0, segment*Element.Rating, Height);
            var paint = new Paint()
            {
                Color = Android.Graphics.Color.Chocolate
            };
            canvas.DrawRect(rect, paint);
            base.Draw(canvas);
        }
    }
}