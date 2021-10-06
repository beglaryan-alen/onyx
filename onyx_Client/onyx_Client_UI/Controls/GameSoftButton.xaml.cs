using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace onyx_Client_UI.Controls
{
    /// <summary>
    /// Логика взаимодействия для GameSoftButton.xaml
    /// </summary>
    public partial class GameSoftButton : UserControl
    {
        public GameSoftButton()
        {
            InitializeComponent();
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Btn.Background.Opacity = 0.2;
            OpenLabel.Visibility = Visibility.Visible;
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Btn.Background.Opacity = 1.0;
            OpenLabel.Visibility = Visibility.Hidden;
        }
    }
}
