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

            TextColor = Color.FromHex("#FFFFFF");
            CardColor = Color.FromHex("#B83F83");

            GoBackCommand = new Command(this.GoBack);
            ColorPickerCommand = new Command<object>(this.ColorPicker);
            //For future
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

        public ICommand ColorPickerCommand { get; set; }

        private void ColorPicker(object obj)
        {

            var colors = (obj as string).Split('|');
            CardColor = Color.FromHex(colors[0]);
            TextColor = Color.FromHex(colors[1]);
        }

        private RoleModel role;
        public RoleModel Role
        {
            get => role;
            set => SetProperty(ref role, value, nameof(Role));
        }

        private Color cardColor;
        public Color CardColor
        {
            get => cardColor;
            set => SetProperty(ref cardColor, value, nameof(CardColor));
        }

        private Color textColor;
        public Color TextColor
        {
            get => textColor;
            set => SetProperty(ref textColor, value, nameof(TextColor));
        }

    }
}
