using Android.Content;
using Android.Graphics;
using GorillaRoasters.CustumViews;
using GorillaRoasters.Droid;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CoffeeFrame), typeof(CoffeeFrameRenderer))]
namespace GorillaRoasters.Droid
{
    public class CoffeeFrameRenderer: FrameRenderer
    {
        public CoffeeFrameRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null || e.OldElement != null) return;
            Control.Elevation = 0f;
            Control.TranslationZ = 30f;

        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            
        }
        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
                StrokeWidth = 4,
                AntiAlias = true,
                Color = Android.Graphics.Color.Gray
            };
            paint.SetShadowLayer(20f, 0f, 0f, Android.Graphics.Color.Black);
            paint.SetStyle(Paint.Style.Stroke);
            
            var rect = new Android.Graphics.RectF(0, 0, Width, Height);
            canvas.DrawRoundRect(rect, Control.Radius, Control.Radius, paint);
           
        }
    }
}