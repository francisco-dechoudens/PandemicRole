using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Input;
using PandemicRole.Infrastructure.Globalization;
using Xamarin.Forms;

namespace PandemicRole.ViewModels
{
    public class SelectedRolePageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private readonly Random _random = new Random();

        public SelectedRolePageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            var rm = new ResourceManager("PandemicRole.Infrastructure.Globalization.Localization", Assembly.GetExecutingAssembly());

            var number =_random.Next(1,89);
            role = rm.GetString($"Role_{number}");
            roleDescription= rm.GetString($"Role_{number}_Description").Replace("\\n", Environment.NewLine);


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

        private string role;
        public string Role
        {
            get
            {
                return this.role;
            }

            set
            {
                if (this.role == value)
                {
                    return;
                }

                this.role = value;
                this.NotifyPropertyChanged();
            }
        }

        private string roleDescription;
        public string RoleDescription
        {
            get
            {
                return this.roleDescription;
            }

            set
            {
                if (this.roleDescription == value)
                {
                    return;
                }

                this.roleDescription = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}
