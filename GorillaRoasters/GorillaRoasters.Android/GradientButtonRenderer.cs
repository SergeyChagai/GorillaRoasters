using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using GorillaRoasters.CustumViews;
using GorillaRoasters.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace GorillaRoasters.Droid
{
    public class GradientButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {
        public GradientButtonRenderer(Context context) : base(context)
        {
            SetWillNotDraw(false);
        }

        //protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Button> e)
        //{
        //    base.OnElementChanged(e);
        //    if (e?.NewElement == null) return;
        //    Control.SetBackground(GetGradient());
        //}
        //public GradientDrawable GetGradient()
        //{
        //    Android.Graphics.Color color = Element.BackgroundColor.ToAndroid();
        //    var gradient = new GradientDrawable(GradientDrawable.Orientation.BottomTop, new[]{
        //        Android.Graphics.Color.Black.ToArgb(), color.ToArgb(), Android.Graphics.Color.White.ToArgb()
        //    });
        //    gradient.SetAlpha(200);
        //    return gradient;
        //}

        public override void Draw(Canvas canvas)
        {
            //base.Draw(canvas);
            Android.Graphics.Color color = Element.BackgroundColor.ToAndroid();
            float[] segments = null;
            var textGradient = new LinearGradient(0, Height/3, 0, 2*Height/3,
                new int[]
                {
                    Android.Graphics.Color.Rgb(142, 123,95),
                    Android.Graphics.Color.Black.ToArgb(),
                },
                segments,
                Shader.TileMode.Mirror);
            var textPaint = new Paint()
            {
                TextAlign = Paint.Align.Center,
                TextSize = 50,
            };
            textPaint.SetShader(textGradient);
            textPaint.SetShadowLayer(5f, 2f, 1f, Android.Graphics.Color.Black);
            
            var gradient = new LinearGradient(0, 0, 0, Height,
                new int[]
                {
                    Android.Graphics.Color.White.ToArgb(),
                    color.ToArgb(),
                    Android.Graphics.Color.Black.ToArgb()
                },
                segments, Shader.TileMode.Clamp
                );
            var paint = new Paint();
            paint.SetShader(gradient);
            var rect = new RectF(Left, Top, Right, Bottom);
            canvas.DrawRect(rect, paint);
            canvas.DrawText(Element.Text, Width / 2, 2 * Height / 3, textPaint);
        }
    }
}