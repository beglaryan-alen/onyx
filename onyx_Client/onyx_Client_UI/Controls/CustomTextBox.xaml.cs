using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace onyx_Client_UI.Controls
{
    /// <summary>
    /// Interaction logic for CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        private string _placeHolder;

        public CustomTextBox()
        {
            InitializeComponent();
        }

        #region Public Properties

        public static readonly DependencyProperty CornerRadiusProperty = 
            DependencyProperty.Register(nameof(CornerRadius), typeof(int), typeof(CustomTextBox));
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(CustomTextBox));
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(CustomTextBox));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty IsPasswordProperty =
            DependencyProperty.Register(nameof(IsPassword), typeof(bool), typeof(CustomTextBox));
        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        #endregion

        #region Private Helpers

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Placeholder))
                _placeHolder = Placeholder;
            Placeholder = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Placeholder = _placeHolder;
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Text = passwordBox.Password;
        }

        #endregion
    }
}
