using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PrismSampleApp.CustomRender;
using PrismSampleApp.Droid;

[assembly: ExportRenderer(typeof(CustomRenderer), typeof(CustomRendererAndroid))]
namespace PrismSampleApp.Droid
{
    class CustomRendererAndroid : EntryRenderer
    {
        public CustomRendererAndroid(Context context) : base(context)
        {
        }

        CustomRenderer _customRenderer;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                _customRenderer = (CustomRenderer)e.NewElement;
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(_customRenderer.EntryCornerRadius);
                gradientDrawable.SetStroke(10, _customRenderer.EntryBorderColor.ToAndroid());

                Control.SetBackground(gradientDrawable);
            }
        }
    }
}