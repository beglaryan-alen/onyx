using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace onyx_Client_UI.Controls
{
    public enum Pages
    {
        Games,
        Soft,
        Promocode,
        Bar,
        Reservation,
        Cybershoke,
    }

    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
        }

        #region Public Properties

        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register(nameof(PageIndex), typeof(Pages), typeof(NavigationBar));
        public Pages PageIndex
        {
            get { return (Pages)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        #endregion

        #region Private Helpers

        private void GamesButton_Clicked(object sender, RoutedEventArgs e)
        {
            PageIndex = Pages.Games;
        }

        private void SoftButton_Clicked(object sender, MouseButtonEventArgs e)
        {
            PageIndex = Pages.Soft;
        }

        private void PromocodeButton_Clicked(object sender, MouseButtonEventArgs e)
        {
            PageIndex = Pages.Promocode;
        }

        private void BarButton_Clicked(object sender, RoutedEventArgs e)
        {
            PageIndex = Pages.Bar;
        }

        private void ReservationButton_Clicked(object sender, MouseButtonEventArgs e)
        {
            PageIndex = Pages.Reservation;
        }

        private void CybershokeButton_Clicked(object sender, MouseButtonEventArgs e)
        {
            PageIndex = Pages.Cybershoke;
        }

        #endregion

    }
}
