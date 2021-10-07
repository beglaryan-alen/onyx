using onyx_Client_UI.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace onyx_Client_UI.Views.Home
{
    /// <summary>
    /// Interaction logic for GamesView.xaml
    /// </summary>
    public partial class GamesView : UserControl
    {
        public GamesView()
        {
            InitializeComponent();
<<<<<<< HEAD
=======

            //var btns = DefaultButtons();
            //foreach (var b in btns)
            //{
            //    WP_Games.Children.Add(b);
            //}
        }



        IEnumerable<GameSoftButton> DefaultButtons()
        {
            List<GameSoftButton> btns = new List<GameSoftButton>();

            var cod = new GameSoftButton();
            btns.Add(GetButton(@"https://mir-s3-cdn-cf.behance.net/project_modules/disp/5c28ce7415941.560ab08bb7ac4.jpg"));
            btns.Add(GetButton(@"https://2.bp.blogspot.com/-7es8LvMKcQM/XH6E1QaIUHI/AAAAAAAAAXw/EXFTrPPv6VMJ01Q30lTirvBGckwI4Bg4QCKgBGAs/w1334-h1334-p-k-no-nu/pubg-explosion-playerunknowns-battlegrounds-uhdpaper.com-4K-10.jpg"));
            btns.Add(GetButton(@"https://i.pinimg.com/736x/14/4c/d0/144cd0f4e958b78f1246b3a43e3fadfb.jpg"));
            btns.Add(GetButton(@"https://i.pinimg.com/originals/f3/19/52/f319529c802e4797e1b1d4b7a1aba6f8.jpg"));
            btns.Add(GetButton(@"https://i.pinimg.com/736x/1b/c1/09/1bc109894636cc9e70eb4a459c2f78e4.jpg"));
            btns.Add(GetButton(@"https://torako.wakarimasen.moe/file/torako/v/image/1618/14/1618145299038.jpg"));
            btns.Add(GetButton(@"https://img.wallpapersafari.com/tablet/768/1024/34/13/6pHNa5.jpg"));
            btns.Add(GetButton(@"https://www.digiseller.ru/preview/714654/p1_2568764_80713596.jpg"));
            return btns;
        }

       


        ImageBrush ConvertBase64ToImageBrush(string value)
        {
            ImageBrush brush = new ImageBrush();
            BitmapImage bitmap = new BitmapImage();
            byte[] binaryData = System.Convert.FromBase64String((string)value);
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(binaryData);
            bitmap.EndInit();
            brush.ImageSource = bitmap;
            return brush;
        }


        GameSoftButton GetButton(string uri, string label = "")
        {
            var b = new GameSoftButton();
            //b.Label.Content = label;
            b.Background = new ImageBrush(new BitmapImage(new Uri(uri)));
            return b;

>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            var border = sender as Border;
            var label =(Label)border.FindName("OpenLabel");
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
