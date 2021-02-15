using System;
using System.Collections.Generic;
using MvvmHelpers;
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
            set => SetProperty(ref roleKey, value, nameof(RoleKey));
        }

        private string roleName;
        public string RoleName
        {
            get => roleName;
            set => SetProperty(ref roleName, value, nameof(RoleName));
        }

        private string roleDescription;
        public string RoleDescription
        {
            get => roleDescription;
            set => SetProperty(ref roleDescription, value, nameof(RoleDescription));
        }

        private string roleOrigin;
        public string RoleOrigin
        {
            get => roleOrigin;
            set => SetProperty(ref roleOrigin, value, nameof(RoleOrigin));
        }
    }
}
