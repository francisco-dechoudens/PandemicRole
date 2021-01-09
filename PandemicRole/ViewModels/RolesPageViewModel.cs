using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using PandemicRole.Views;
using Xamarin.Forms;

namespace PandemicRole.ViewModels
{
    public class RolesPageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private List<string> roles;
        public List<string> Roles
        {
            get => roles;
            set => SetValue(ref roles, value, nameof(Roles));
        }

        public RolesPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            roles = new List<string>();

            var rm = new ResourceManager("PandemicRole.Infrastructure.Globalization.Localization", Assembly.GetExecutingAssembly());

            foreach (var resource in rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                var r = (System.Collections.DictionaryEntry)resource;
                if (Regex.IsMatch(r.Key.ToString(), @"^Role_.*\d$"))
                {
                    roles.Add(r.Value.ToString());
                }
            }

            roles.Sort();

            RoleSelectedCommand = new Command<string>(this.RoleSelected);
        }

        public ICommand RoleSelectedCommand { get; private set; }

        private async void RoleSelected(string role)
        {
            var detailPage = new SelectedRolePage();
            detailPage.BindingContext = new SelectedRolePageViewModel(this.Navigation);

            await this.Navigation.PushAsync(detailPage);
        }

    }
}
