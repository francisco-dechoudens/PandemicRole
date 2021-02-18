using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PandemicRole.Views.Controls
{
    public partial class ColorPickerView : ContentView
    {
        public ColorPickerView()
        {
            InitializeComponent();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var algo = sender as Xamarin.Forms.Shapes.Ellipse;

            var scb = algo.Fill as SolidColorBrush;

            var color = scb.Color;

            //Execute(ActionCommand);
        }


        #region ActionCommand

        public static readonly BindableProperty ActionCommandProperty =
            BindableProperty.Create(nameof(ActionCommand), typeof(ICommand), typeof(ColorPickerView), null);

        public ICommand ActionCommand
        {
            get => (ICommand)GetValue(ActionCommandProperty);
            set => SetValue(ActionCommandProperty, value);
        }

        #endregion ActionCommand

        #region ActionCommandParameter

        public static readonly BindableProperty ActionCommandParameterProperty =
            BindableProperty.Create(nameof(ActionCommandParameter), typeof(object), typeof(ColorPickerView), null);

        public object ActionCommandParameter
        {
            get => GetValue(ActionCommandParameterProperty);
            set => SetValue(ActionCommandParameterProperty, value);
        }

        #endregion ActionCommandParameter

        // Helper method for invoking commands safely
        public static void Execute(ICommand command)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(null);
            }
        }
    }
}
