using System;
using System.Collections.Generic;
using PandemicRole.ViewModels;
using Xamarin.Forms;

namespace PandemicRole.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(Navigation);
        }
    }
}
