using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PrismSampleApp.CustomRender;
using PrismSampleApp.iOS;

[assembly: ExportRenderer(typeof(CustomRenderer), typeof(CustomRendererIOS))]
namespace PrismSampleApp.iOS
{
    public class CustomRendererIOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var customEntry = (CustomRenderer)e.NewElement;

                Control.Layer.CornerRadius = customEntry.EntryCornerRadius;
                Control.Layer.BorderColor = customEntry.EntryBorderColor.ToCGColor();

                Control.Layer.BorderWidth = 2;
            }
        }
    }
}