using onyx_Client_UI.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace onyx_Client_UI.Views.Home
{
    /// <summary>
    /// Interaction logic for SoftsView.xaml
    /// </summary>
    public partial class SoftView : UserControl
    {
        public SoftView()
        {
            InitializeComponent();
<<<<<<< HEAD
=======
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
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
        }
    }

    
}
