using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;

namespace PandemicRole.ViewModels
{
    public class RolesPageViewModel : BaseViewModel
    {
        public RolesPageViewModel()
        {
            this.roles = new List<string>();

            var rm = new ResourceManager("PandemicRole.Infrastructure.Globalization.Localization", Assembly.GetExecutingAssembly());

            foreach (var resource in rm.GetResourceSet(CultureInfo.CurrentCulture, true, true))
            {
                var r = (System.Collections.DictionaryEntry)resource;
                if (Regex.IsMatch(r.Key.ToString(), @"^Role_.*\d$"))
                {
                    this.roles.Add(r.Value.ToString());
                }
            }

            this.roles.Sort();
        }

        private List<string> roles;
        public List<string> Roles
        {
            get => roles;
            set => SetValue(ref roles, value, nameof(Roles));
        }

    }
}
