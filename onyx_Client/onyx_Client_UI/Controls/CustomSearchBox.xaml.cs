using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace onyx_Client_UI.Controls
{
    /// <summary>
    /// Interaction logic for CustomSearchBox.xaml
    /// </summary>
    public partial class CustomSearchBox : UserControl
    {
        private string _placeholder;
        public CustomSearchBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(CustomSearchBox));
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(CustomSearchBox));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Placeholder))
                _placeholder = Placeholder;
            Placeholder = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Placeholder = _placeholder;
            }
        }
    }
}
