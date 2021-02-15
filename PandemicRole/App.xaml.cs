using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PandemicRole.Views;
using PandemicRole.Data;

namespace PandemicRole
{
    public partial class App : Application
    {
        static RoleRepository repository;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }

        public static RoleRepository Repository
        {
            get
            {
                if (repository == null)
                {
                    repository = new RoleRepository();
                }
                return repository;
            }
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
