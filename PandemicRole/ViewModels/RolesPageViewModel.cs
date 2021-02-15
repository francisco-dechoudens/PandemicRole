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
            

            RoleSelectedCommand = new Command(this.RoleSelected);
        }


        internal async Task OnAppearing()
        {
            await LoadList();
        }

        private async Task LoadList()
        {
            var roleList = await App.Repository.GetItemsAsync();
            var fillRoleModel = new List<RoleModel>();

            foreach (var role in roleList.Where(rl => rl.Origin == "BaseGame"))
            {
                fillRoleModel.Add(new RoleModel()
                {
                    RoleKey = role.ID.ToString(),
                    RoleName = role.Name,
                    RoleDescription = role.Description
                });
            }

            Roles = fillRoleModel.OrderBy(r => r.RoleName).ToList();
        }

        public ICommand RoleSelectedCommand { get; private set; }

        private async void RoleSelected()
        {
            if (SelectedRole != null)
            {
                var detailPage = new SelectedRolePage();
                detailPage.BindingContext = new SelectedRolePageViewModel(this.Navigation, SelectedRole);
                await this.Navigation.PushAsync(detailPage);
                SelectedRole = null;
            }
        }

    }
}
