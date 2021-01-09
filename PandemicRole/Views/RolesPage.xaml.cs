using System;
using System.Collections.Generic;
using PandemicRole.ViewModels;
using Xamarin.Forms;

namespace PandemicRole.Views
{
    public partial class RolesPage : ContentPage
    {
        public RolesPage()
        {
            InitializeComponent();
            BindingContext = new RolesPageViewModel(Navigation);
        }
    }
}
