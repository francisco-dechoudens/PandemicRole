using System;
using System.Linq;
using System.Windows.Input;
using MvvmHelpers;
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
            BlisherSelectedCommand = new Command(this.BlisherSelectedClicked);
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


            var roleList = await App.Repository.GetItemsAsync();
            var roles = roleList.Where(rl => rl.Origin != "FanMade");

            Random rand = new Random();
            int toSkip = rand.Next(0, roles.Count());

            var randomRole = roles.Skip(toSkip).Take(1).First();
            var model = new Models.RoleModel()
            {
                RoleKey = randomRole.ID.ToString(),
                RoleName = randomRole.Name,
                RoleDescription = randomRole.Description,
                RoleOrigin = randomRole.Origin
            };

            detailPage.BindingContext = new SelectedRolePageViewModel(this.Navigation, model);

            await this.Navigation.PushAsync(detailPage);
        }

        public ICommand BlisherSelectedCommand { get; private set; }

        private async void BlisherSelectedClicked()
        {
            var detailPage = new SelectedRolePage();

            var role = await App.Repository.GetItemByNameAsync("Blisher (Pipeline)");

            var model = new Models.RoleModel()
            {
                RoleKey = role.ID.ToString(),
                RoleName = role.Name,
                RoleDescription = role.Description,
                RoleOrigin = role.Origin
            };

            detailPage.BindingContext = new SelectedRolePageViewModel(this.Navigation, model);

            await this.Navigation.PushAsync(detailPage);
        }
        
    }
}
