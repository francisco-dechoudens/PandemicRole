using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PandemicRole.Views;

namespace PandemicRole
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RolesPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
