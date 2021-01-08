using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms.Internals;

using System;
namespace PandemicRole.ViewModels
{
    /// <summary>
    /// This viewmodel extends in another viewmodels.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the value of the property and calls <see cref="OnPropertyChanged"/> to
        /// raise the <see cref="PropertyChanged"/> event.
        /// <para>NOTE: The value is only set if, and only if, the old and new values
        /// are not equal.</para>
        /// </summary>
        /// <typeparam name="T">The type of the observed object.</typeparam>
        /// <param name="field">The field of the observed object as reference.</param>
        /// <param name="newValue">The new value to be assigned to the observed object.</param>
        /// <param name="propertyName">The name of the property of the observed object.</param>
        /// <param name="action">An action to be executed if the value changes.</param>
        protected void SetValue<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null, Action action = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return;
            }

            field = newValue;
            NotifyPropertyChanged(propertyName);
            action?.Invoke();
        }

        #endregion
    }
}
