using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using PandemicRole.Models;
using PandemicRole.Views;
using Xamarin.Forms;

namespace PandemicRole.ViewModels
{
    public class RolesPageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public ObservableRangeCollection<RoleModel> AllRoles { get; set; }
        public ObservableRangeCollection<RoleModel> Roles { get; set; }

        private RoleModel selectedRole;
        public RoleModel SelectedRole
        {
            get => selectedRole;
            set => SetProperty(ref selectedRole, value, nameof(SelectedRole));
        }

        string selectedFilter = "All";
        public string SelectedFilter
        {
            get => selectedFilter;
            set
            {
                if (SetProperty(ref selectedFilter, value))
                    FilterItems();
            }
        }

        public ObservableRangeCollection<string> FilterOptions { get; }
        public ICommand LoadItemsCommand { get; private set; }

        public RolesPageViewModel(INavigation navigation)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.FromHex("#0B306B");
            navigationPage.BarTextColor = Color.White;

            this.Navigation = navigation;
            Roles = new ObservableRangeCollection<RoleModel>();
            AllRoles = new ObservableRangeCollection<RoleModel>();

            FilterOptions = new ObservableRangeCollection<string>
            {
                "All",
                "Base Game",
                "In The Lab",
                "On The Brink",
                "State Of Emergency"
            };

            RoleSelectedCommand = new Command(this.RoleSelected);

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        internal async Task OnAppearing()
        {
            await ExecuteLoadItemsCommand();
        }

        void FilterItems()
        {
            Roles.ReplaceRange(AllRoles.Where(a => a.RoleOrigin == SelectedFilter.Replace(" ","") || SelectedFilter == "All"));
        }

        private async Task LoadList()
        {
            //var roleList = await App.Repository.GetItemsAsync();
            //var fillRoleModel = new List<RoleModel>();

            //foreach (var role in roleList.Where(rl => rl.Origin == "BaseGame"))
            //{
            //    fillRoleModel.Add(new RoleModel()
            //    {
            //        RoleKey = role.ID.ToString(),
            //        RoleName = role.Name,
            //        RoleDescription = role.Description
            //    });
            //}

            //Roles = fillRoleModel.OrderBy(r => r.RoleName).ToList();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var roleList = await App.Repository.GetItemsAsync();
                var fillRoleModel = new List<RoleModel>();

                foreach (var role in roleList.Where(rl => rl.Origin != "FanMade"))
                {
                    fillRoleModel.Add(new RoleModel()
                    {
                        RoleKey = role.ID.ToString(),
                        RoleName = role.Name,
                        RoleDescription = role.Description,
                        RoleOrigin = role.Origin
                    });
                }

                AllRoles.ReplaceRange(fillRoleModel.OrderBy(r => r.RoleName).AsEnumerable());
                FilterItems();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
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
