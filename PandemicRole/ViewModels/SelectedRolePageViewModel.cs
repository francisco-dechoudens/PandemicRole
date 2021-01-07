using System;
using PandemicRole.Infrastructure.Globalization;

namespace PandemicRole.ViewModels
{
    public class SelectedRolePageViewModel : BaseViewModel
    {
        public SelectedRolePageViewModel()
        {
            this.role = Localization.Role_15;
            this.roleDescription = Localization.Role_15_Description.Replace("\\n", Environment.NewLine);
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
