using onyx_Client_UI.ViewModels;
using System.Windows.Controls;

namespace onyx_Client_UI.Views
{
    /// <summary>
    /// Interaction logic for GamesView.xaml
    /// </summary>
    public partial class GamesView : UserControl
    {
        public GamesView()
        {
            InitializeComponent();
            DataContext = new GamesViewModel();
        }
    }
}
