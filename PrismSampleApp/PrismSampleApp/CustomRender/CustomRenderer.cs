using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrismSampleApp.CustomRender
{
    public class CustomRenderer : Entry
    {
        public static readonly string Description = "Random Api Data";
        public static readonly BindableProperty CornerRadiusProperty =
          BindableProperty.Create("CornerRadius", typeof(int), typeof(CustomRenderer), 0);

        public int EntryCornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
          BindableProperty.Create("BorderThickness", typeof(Color), typeof(CustomRenderer), Color.AliceBlue);

        public Color EntryBorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

    }
}