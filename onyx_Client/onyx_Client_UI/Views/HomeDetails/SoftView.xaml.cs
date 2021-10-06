using onyx_Client_UI.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
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
            var btns = DefaultButtons();
            foreach (var b in btns)
            {
                WP_Soft.Children.Add(b);
            }
        }
        IEnumerable<GameSoftButton> DefaultButtons()
        {
            List<GameSoftButton> btns = new List<GameSoftButton>();

            var cod = new GameSoftButton();
            btns.Add(GetButton(@"https://img.wallpapersafari.com/tablet/768/1024/25/21/UPTWvw.png","Discord"));
            btns.Add(GetButton(@"https://sun9-29.userapi.com/c851016/v851016918/103470/Ae3j5rAM430.jpg"));
            btns.Add(GetButton(@"https://i.ytimg.com/vi/T8GIX7D6zDE/maxresdefault.jpg"));
            btns.Add(GetButton(@"https://f.vividscreen.info/soft/0db32198a6dd6c59244ab4e7153a136b/Google-Chrome-1080x1920.jpg"));
            btns.Add(GetButton(@"https://brit03.ru/wp-content/uploads/kak-uznat-versiyu-opery0.jpg"));
            return btns;
        }
        GameSoftButton GetButton(string uri, string label = "")
        {
            var b = new GameSoftButton();
            b.Label.Content = label;
            b.Btn.Background = new ImageBrush(new BitmapImage(new Uri(uri)));
            return b;

        }
    }

    
}
