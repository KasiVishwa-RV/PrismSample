﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorldTimePage : TabbedPage
    {
        public WorldTimePage()
        {
            InitializeComponent();
        }
    }
}