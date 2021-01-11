using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using PandemicRole.Models;
using PandemicRole.Views;
using Xamarin.Forms;

namespace PandemicRole.ViewModels
{
    public class RolesPageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private List<RoleModel> roles;
        public List<RoleModel> Roles
        {
            get => roles;
            set => SetValue(ref roles, value, nameof(Roles));
        }

        private RoleModel selectedRole;
        public RoleModel SelectedRole
        {
            get => selectedRole;
            set => SetValue(ref selectedRole, value, nameof(SelectedRole));
        }

        public RolesPageViewModel(INavigation navigation)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Black;
            navigationPage.BarTextColor = Color.White;

            this.Navigation = navigation;
            roles = new List<RoleModel>();

            var rm = new ResourceManager("PandemicRole.Infrastructure.Globalization.Localization", Assembly.GetExecutingAssembly());

            foreach (var resource in rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                var r = (System.Collections.DictionaryEntry)resource;
                if (Regex.IsMatch(r.Key.ToString(), @"^Role_.*\d$"))
                {
                    roles.Add(new RoleModel(){
                        RoleKey = r.Key.ToString(),
                        RoleName = r.Value.ToString()
                    });;
                }
            }

            roles = roles.OrderBy(r => r.RoleName).ToList();

            RoleSelectedCommand = new Command(this.RoleSelected);
        }

        public ICommand RoleSelectedCommand { get; private set; }

        private async void RoleSelected()
        {
            var detailPage = new SelectedRolePage();
            detailPage.BindingContext = new SelectedRolePageViewModel(this.Navigation, SelectedRole);

            await this.Navigation.PushAsync(detailPage);
        }

    }
}
