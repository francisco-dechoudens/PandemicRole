using System;
using System.Collections.Generic;
using Xamarin.Forms;
using PandemicRole.Infrastructure.Globalization;

namespace PandemicRole.Views
{
    public partial class SelectedRolePage : ContentPage
    {
        public SelectedRolePage()
        {
            InitializeComponent();
            role_description.Text = Localization.Role_15_Description.Replace("\\n", Environment.NewLine);
        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //
        //    if (width < height)
        //    {
        //        // In portrait Mode
        //        background_img.Source = "bg-portrait.png";
        //    }
        //    else
        //    {
        //        //In Landscape mode
        //        background_img.Source = "bg.png";
        //    }
        //}
    }
}
