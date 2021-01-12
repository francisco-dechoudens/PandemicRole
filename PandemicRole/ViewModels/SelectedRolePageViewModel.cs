using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Input;
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

            var rm = new ResourceManager("PandemicRole.Infrastructure.Globalization.Localization", Assembly.GetExecutingAssembly());
            if (roleModel == null)
            {
                var number = _random.Next(1, 89);
                Role = new RoleModel()
                {
                    RoleKey = $"Role_{number}",
                    RoleName = rm.GetString($"Role_{number}"),
                    RoleDescription = rm.GetString($"Role_{number}_Description").Replace("\\n", Environment.NewLine)
                };
            }
            else {
                roleModel.RoleName = rm.GetString($"{roleModel.RoleKey}");
                roleModel.RoleDescription = rm.GetString($"{roleModel.RoleKey}_Description").Replace("\\n", Environment.NewLine);
                Role = roleModel;
            }


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
            set => SetValue(ref role, value, nameof(Role));
        }
    }
}
