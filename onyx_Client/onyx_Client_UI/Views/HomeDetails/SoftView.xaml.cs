using System.Windows.Controls;
using System.Windows.Input;

namespace onyx_Client_UI.Views.HomeDetails
{
    /// <summary>
    /// Interaction logic for SoftsView.xaml
    /// </summary>
    public partial class SoftView : UserControl
    {
        public SoftView()
        {
            InitializeComponent();

        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            var label = (Label)border.FindName("OpenLabel");
            var b = (Border)border.FindName("Btn");
            b.Background.Opacity = 0.2;
            label.Visibility = System.Windows.Visibility.Visible;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            var label = (Label)border.FindName("OpenLabel");
            var b = (Border)border.FindName("Btn");
            b.Background.Opacity = 1;
            label.Visibility = System.Windows.Visibility.Hidden;
        }
    }

    
}
