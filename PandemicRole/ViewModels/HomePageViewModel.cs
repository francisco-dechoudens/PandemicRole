﻿using System;
using System.Windows.Input;
using PandemicRole.Views;
using Xamarin.Forms;

namespace PandemicRole.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public HomePageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            SelectRoleCommand = new Command(this.SelectRoleClicked);
            RandomRoleCommand = new Command(this.RandomRoleClicked);
        }


        public ICommand SelectRoleCommand { get; private set; }

        private async void SelectRoleClicked()
        {
            var detailPage = new RolesPage();
            detailPage.BindingContext = new RolesPageViewModel(this.Navigation);

            await this.Navigation.PushAsync(detailPage);
        }

        public ICommand RandomRoleCommand { get; private set; }

        private async void RandomRoleClicked()
        {
            var detailPage = new SelectedRolePage();
            detailPage.BindingContext = new SelectedRolePageViewModel(this.Navigation, null);

            await this.Navigation.PushAsync(detailPage);
        }
    }
}
