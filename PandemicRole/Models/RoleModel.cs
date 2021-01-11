using System;
using System.Collections.Generic;
using PandemicRole.ViewModels;

namespace PandemicRole.Models
{
    public class RoleModel : BaseViewModel
    {
        public RoleModel()
        {
        }

        private string roleKey;
        public string RoleKey
        {
            get => roleKey;
            set => SetValue(ref roleKey, value, nameof(RoleKey));
        }

        private string roleName;
        public string RoleName
        {
            get => roleName;
            set => SetValue(ref roleName, value, nameof(RoleName));
        }

        private string roleDescription;
        public string RoleDescription
        {
            get => roleDescription;
            set => SetValue(ref roleDescription, value, nameof(RoleDescription));
        }
    }
}
