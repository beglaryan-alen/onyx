using onyx_Client_UI.ViewModels;
using System.Windows.Controls;

namespace onyx_Client_UI.Views
{
    /// <summary>
    /// Interaction logic for SoftsView.xaml
    /// </summary>
    public partial class SoftView : UserControl
    {
        public SoftView()
        {
            InitializeComponent();
            DataContext = new SoftViewModel();
        }
    }
}
