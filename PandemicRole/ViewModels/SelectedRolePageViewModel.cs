using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Input;
using MvvmHelpers;
using PandemicRole.Infrastructure.Globalization;
using PandemicRole.Models;
using Xamarin.Forms;

namespace PandemicRole.ViewModels
{
    public class SelectedRolePageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private readonly Random _random = new Random();

        public SelectedRolePageViewModel(INavigation navigation, RoleModel roleModel)
        {
            Navigation = navigation;


   

            Role = roleModel;


            GoBackCommand = new Command(this.GoBack);

            //FOr future
            //var Links = new Dictionary<string, string>();
            //foreach (var resource in rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            //{
            //    var r = (System.Collections.DictionaryEntry)resource;
            //    Links.Add(r.Key.ToString(), r.Value.ToString());
            //}
        }

        public ICommand GoBackCommand { get; private set; }

        private async void GoBack()
        {
            await this.Navigation.PopAsync();
        }

        private RoleModel role;
        public RoleModel Role
        {
            get => role;
            set => SetProperty(ref role, value, nameof(Role));
        }
    }
}
