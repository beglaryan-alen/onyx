﻿using Onyx.Config;
using System.Windows;

namespace onyx_Client_UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Config config = Config.getConfig();
    }
}
