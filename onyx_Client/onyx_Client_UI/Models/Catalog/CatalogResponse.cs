<<<<<<< HEAD
﻿namespace onyx_Client_UI.Models.Catalog
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace onyx_Client_UI.Models.Catalog
>>>>>>> 293a9faa17276849bbd97725b0679c2aa76084cf
{
    public class ApplicationCatalogResponse
    {
        public string ImageUrl { get; set; }
        public string SoftUrl { get; set; }
        public string AppUrl { get; set; }
        public string Name { get; set; }

        public ImageBrush BackGround => new ImageBrush(new BitmapImage(new Uri(ImageUrl)));
    }
}
